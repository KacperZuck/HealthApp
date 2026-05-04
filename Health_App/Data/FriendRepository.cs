using Health_App.Common;
using Health_App.Data.Interface;
using Health_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Health_App.Data
{
    public class FriendRepository : Repository<Friends>, IFriendRepository
    {
        public FriendRepository(ConfigDbContext contex) : base(contex)
        {
        }

        public async Task<List<Guid>> GetFriendIdsAsync(Guid userId)
        {
            return await _dbContext.friends
                .Where(x => x.userId == userId || x.friendId == userId) // w obu kolumnach
                .Select(y => y.userId == userId ? y.friendId : y.userId) // drugie
                .ToListAsync();
        }

        public async Task<bool> IsFriendAsync(Guid userId, Guid friendId)
        {
            return await _dbContext.friends.AnyAsync(x => x.userId == userId && x.friendId == friendId);
        }
    }
}
