using Health_App.Common.Interface;
using Health_App.Models;

namespace Health_App.Data.Interface
{
    public interface IFriendRepository : IRepository<Friends>
    {
        Task<List<Guid>> GetFriendIdsAsync(Guid userId);
        Task<bool> IsFriendAsync(Guid userId, Guid friendId);
    }
}
