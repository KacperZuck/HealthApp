using Common;
using Health_App.Common.Interface;
using Health_App.Models;

namespace Health_App.Data.Interface
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
    }
}
