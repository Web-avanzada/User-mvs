using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace Service.SUserService
{
    public class SUserProfile : IGenericService<UserProfile>
    {
        private readonly DataContext _context;

        public SUserProfile(DataContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> CreateAsync(UserProfile entity)
        {
            entity.CreateDate = DateTime.UtcNow;

            _context.UserProfiles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return false;
            }

            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles
                                 .FirstOrDefaultAsync(up => up.UserProfilesId == id);
        }

        public async Task<UserProfile> UpdateAsync(int id, UserProfile entity)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return null;
            }

            // Update all relevant fields from the incoming entity
            userProfile.Name = entity.Name;
            userProfile.LastName = entity.LastName; // New field
            userProfile.Address = entity.Address;
            userProfile.Phone = entity.Phone;
            userProfile.Mail = entity.Mail;
            userProfile.DateOfBirth = entity.DateOfBirth; // New field
            userProfile.OccupationInterests = entity.OccupationInterests; // New field
            userProfile.Status = entity.Status;

            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();

            return userProfile;
        }
    }
}