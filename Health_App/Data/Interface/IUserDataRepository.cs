using Health_App.Common.Interface;
using Health_App.Models;

namespace Health_App.Data.Interface
{
    public interface IUserDataRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<UserData?> GetBy_UserId(Guid id);
        Task<int> Get_LastMesurment(Guid id);
        Task<double> GetAverage(Guid id);
        Task<List<UserData>> Get_LastXRecords(Guid userId, string measurementName, int period);
        Task<List<string>> Get_UniqueNames();
    }
}

