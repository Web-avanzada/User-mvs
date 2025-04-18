using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace Service.SUserService
{
    public class SUserSchedule : IGenericService<UserSchedule>
    {
        private readonly DataContext _context;

        public SUserSchedule(DataContext context)
        {
            _context = context;
        }

        public async Task<UserSchedule> CreateAsync(UserSchedule entity)
        {
 
            _context.UserSchedules.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var userSchedule = await _context.UserSchedules.FindAsync(id);
            if (userSchedule == null)
            {
                return false; 
            }

            _context.UserSchedules.Remove(userSchedule);
            await _context.SaveChangesAsync();

            return true;
        }

      
        public async Task<IEnumerable<UserSchedule>> GetAllAsync()
        {
            return await _context.UserSchedules
                                 .Include(us => us.UserProfile) 
                                 .ToListAsync();
        }

     
        public async Task<UserSchedule> GetByIdAsync(int id)
        {
            return await _context.UserSchedules
                                 .Include(us => us.UserProfile) 
                                 .FirstOrDefaultAsync(us => us.UserScheduleId == id);
        }

       
        public async Task<UserSchedule> UpdateAsync(int id, UserSchedule entity)
        {
            var userSchedule = await _context.UserSchedules.FindAsync(id);
            if (userSchedule == null)
            {
                return null; 
            }

        
            userSchedule.UserProfilesId = entity.UserProfilesId;
            userSchedule.Date = entity.Date;
            userSchedule.StartTime = entity.StartTime;
            userSchedule.EndTime = entity.EndTime;

            _context.UserSchedules.Update(userSchedule);
            await _context.SaveChangesAsync();

            return userSchedule;
        }
    }
}
