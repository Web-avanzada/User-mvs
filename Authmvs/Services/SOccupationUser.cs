using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace Service.SUserService
{
    public class SOccupationUser : IGenericService<OccupationUser>
    {
        private readonly DataContext _context;

        public SOccupationUser(DataContext context)
        {
            _context = context;
        }

       
        public async Task<OccupationUser> CreateAsync(OccupationUser entity)
        {
            _context.OccupationUsers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var occupationUser = await _context.OccupationUsers.FindAsync(id);
            if (occupationUser == null)
                return false;

            _context.OccupationUsers.Remove(occupationUser);
            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<IEnumerable<OccupationUser>> GetAllAsync()
        {
            return await _context.OccupationUsers
                                 .Include(ou => ou.UserProfile)
                                 .Include(ou => ou.Occupation)
                                 .ToListAsync();
        }

        
        public async Task<OccupationUser> GetByIdAsync(int id)
        {
            return await _context.OccupationUsers
                                 .Include(ou => ou.UserProfile)
                                 .Include(ou => ou.Occupation)
                                 .FirstOrDefaultAsync(ou => ou.OccupationTutorId == id);
        }

      
        public async Task<OccupationUser> UpdateAsync(int id, OccupationUser entity)
        {
            var occupationUser = await _context.OccupationUsers.FindAsync(id);
            if (occupationUser == null)
                return null;

            occupationUser.UserProfilesId = entity.UserProfilesId;
            occupationUser.OccupationId = entity.OccupationId;

            _context.OccupationUsers.Update(occupationUser);
            await _context.SaveChangesAsync();
            return occupationUser;
        }
    }
}
