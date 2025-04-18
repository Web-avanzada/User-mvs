using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace Service.SUserService
{
    public class STheme : IGenericService<Theme>
    {
        private readonly DataContext _context;

        public STheme(DataContext context)
        {
            _context = context;
        }

       
        public async Task<Theme> CreateAsync(Theme entity)
        {
            _context.Themes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            var theme = await _context.Themes.FindAsync(id);
            if (theme == null)
                return false;

            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync();
            return true;
        }

       
        public async Task<IEnumerable<Theme>> GetAllAsync()
        {
            return await _context.Themes.ToListAsync();
        }

        
        public async Task<Theme> GetByIdAsync(int id)
        {
            return await _context.Themes.FirstOrDefaultAsync(t => t.ThemeId == id);
        }

        
        public async Task<Theme> UpdateAsync(int id, Theme entity)
        {
            var theme = await _context.Themes.FindAsync(id);
            if (theme == null)
                return null;

            theme.ThemeName = entity.ThemeName;

            _context.Themes.Update(theme);
            await _context.SaveChangesAsync();
            return theme;
        }
    }
}
