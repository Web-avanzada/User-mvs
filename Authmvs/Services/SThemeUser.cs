using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace Service.SUserService
{
    public class SThemeUser : IGenericService<ThemeUser>
    {
        private readonly DataContext _context;

        public SThemeUser(DataContext context)
        {
            _context = context;
        }

       
        public async Task<ThemeUser> CreateAsync(ThemeUser entity)
        {
            _context.ThemeUsers.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var themeUser = await _context.ThemeUsers.FindAsync(id);
            if (themeUser == null)
                return false;

            _context.ThemeUsers.Remove(themeUser);
            await _context.SaveChangesAsync();
            return true;
        }

      
        public async Task<IEnumerable<ThemeUser>> GetAllAsync()
        {
            return await _context.ThemeUsers

                                 .ToListAsync();
        }

       
        public async Task<ThemeUser> GetByIdAsync(int id)
        {
            return await _context.ThemeUsers
                                 .FirstOrDefaultAsync(tu => tu.ThemeStudentId == id);
        }

    
        public async Task<ThemeUser> UpdateAsync(int id, ThemeUser entity)
        {
            var themeUser = await _context.ThemeUsers.FindAsync(id);
            if (themeUser == null)
                return null;

            themeUser.UserProfilesId = entity.UserProfilesId;
            themeUser.ThemeId = entity.ThemeId;

            _context.ThemeUsers.Update(themeUser);
            await _context.SaveChangesAsync();
            return themeUser;
        }
    }
}
