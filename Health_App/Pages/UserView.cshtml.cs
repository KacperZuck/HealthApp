using Health_App.Data;
using Health_App.Data.Interface;
using Health_App.Models;
using Health_App.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace Health_App.Pages
{
    [Authorize]
    public class UserViewModel : PageModel
    {
        private readonly IUserService<User, UserDto> _userService;
        private readonly IUserDataRepository<UserData> _userData;
        private readonly IFriendRepository _friends;
        public ICollection<UserDto> _usersList { get; set; }
        public string _currentUserName { get; set; }
        public List<string> _availableMeasurements { get; set; }
        public int _period = 30;
        public UserViewModel(
            IUserService<User, UserDto> userService,
            IUserDataRepository<UserData> userData,
            IFriendRepository friends)
        {
            _userService = userService;
            _userData = userData;
            _friends = friends;
        }


        public async Task OnGetAsync()
        {
            var currentId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var currentUser = await _userService.Get(currentId);
            if ( currentUser != null)
            {
                _currentUserName = currentUser.name;
            }
            var friendIds = await _friends.GetFriendIdsAsync(currentId);
            var users = await _userService.GetAll();

            _usersList = users.Where(u => friendIds.Contains(u.id) || u.id == currentId).ToList();

            _availableMeasurements = await _userData.Get_UniqueNames();
            foreach (var user in _usersList)
            {
                foreach (var name in _availableMeasurements)
                {
                    var records = await _userData.Get_LastXRecords(user.id, name, _period);

                    if (records.Any())
                    {
                        user.measurements[name] = new UserDataDto
                        {
                            value = records.First().mesurment,
                            avg = (float)records.Average(x => x.mesurment)
                        };
                    }
                }
            }
        }
        public async Task<IActionResult> OnPostAddMeasurementAsync(string MeasurementName, int Value)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim)) return RedirectToPage("/Index");

            var userId = Guid.Parse(userIdClaim);

            var newData = new UserData
            {
                id = Guid.NewGuid(),
                user_id = userId,
                name = MeasurementName,
                mesurment = Value,
                created_at = DateTime.Now
            };

            await _userData.Add(newData);

            TempData["SuccessMessage"] = $"Dodano nowy pomiar dla {MeasurementName}";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddFriendAsync(string friendEmail, string friendName)
        {
            var currentUserIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserIdClaim)) return RedirectToPage("/Index");

            var currentUserId = Guid.Parse(currentUserIdClaim);

            var allUsers = await _userService.GetAll();
            var friend = allUsers.FirstOrDefault(u =>
                u.email.Equals(friendEmail, StringComparison.OrdinalIgnoreCase) &&
                u.name.Equals(friendName, StringComparison.OrdinalIgnoreCase));

            if (friend == null)
            {
                ModelState.AddModelError("", "Nie znaleziono użytkownika o podanym imieniu i adresie e-mail.");
                TempData["ErrorMessage"] = "Błąd: Nie znaleziono użytkownika o takich danych.";
                return RedirectToPage();
            }

            if (friend.id == currentUserId)
            {
                TempData["ErrorMessage"] = "Nie możesz dodać samego siebie do znajomych.";
                return RedirectToPage();
            }

            bool alreadyFriends = await _friends.IsFriendAsync(currentUserId, friend.id);
            if (alreadyFriends)
            {
                TempData["ErrorMessage"] = "Ten użytkownik jest już na Twojej liście znajomych.";
                return RedirectToPage();
            }

            var newFriendship = new Friends
            {
                id = Guid.NewGuid(),
                userId = currentUserId,
                friendId = friend.id
            };

            await _friends.Add(newFriendship);
            TempData["SuccessMessage"] = $"Dodano użytkownika {friendName} do znajomych!";

            return RedirectToPage();
        }
    }
}