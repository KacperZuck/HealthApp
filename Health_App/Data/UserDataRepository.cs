using Health_App.Common;
using Health_App.Data.Interface;
using Health_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Health_App.Data
{
    public class UserDataRepository : Repository<UserData>, IUserDataRepository<UserData>
    {
        public UserDataRepository(ConfigDbContext contaxt) : base(contaxt) { }

        public async Task<UserData?> GetBy_UserId(Guid id)
        {
            return await _dbContext.Set<UserData>().FirstOrDefaultAsync(x => x.user_id == id);
        }
        public async Task<double> GetAverage(Guid id)
        {
            var records = _dbContext.userData.Where(x =>  x.user_id == id);

            if (!await records.AnyAsync()) return 0.0f;

            double avg = await records.AverageAsync(x => (double)x.mesurment);
            return avg;
        }

        public async Task<int> Get_LastMesurment(Guid id)
        {
            return await _dbContext.userData.Where(x => x.user_id == id)
                .OrderByDescending(x => x.created_at).Select(x => x.mesurment).FirstOrDefaultAsync();
        }

        public async Task<List<UserData>> Get_LastXRecords(Guid userId, string measurementName, int period)
        {
            return await _dbContext.userData
                .Where(x => x.user_id == userId && x.name == measurementName)
                .OrderByDescending(x => x.created_at)
                .Take(period)
                .ToListAsync();
        }

        public async Task<List<string>> Get_UniqueNames()
        {
            return await _dbContext.userData
                .Select(x => x.name)
                .Distinct()
                .ToListAsync();
        }
    }
}