using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace Service.SUserService
{
    public class SOccupation : IGenericService<Occupation>
    {
        private readonly DataContext _context;

        public SOccupation(DataContext context)
        {
            _context = context;
        }

       
        public async Task<Occupation> CreateAsync(Occupation entity)
        {
            _context.Occupations.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

   
        public async Task<bool> DeleteAsync(int id)
        {
            var occupation = await _context.Occupations.FindAsync(id);
            if (occupation == null)
                return false;

            _context.Occupations.Remove(occupation);
            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<IEnumerable<Occupation>> GetAllAsync()
        {
            return await _context.Occupations.ToListAsync();
        }

        
        public async Task<Occupation> GetByIdAsync(int id)
        {
            return await _context.Occupations.FirstOrDefaultAsync(o => o.OccupationId == id);
        }

       
        public async Task<Occupation> UpdateAsync(int id, Occupation entity)
        {
            var occupation = await _context.Occupations.FindAsync(id);
            if (occupation == null)
                return null;

            occupation.OccupationName = entity.OccupationName;

            _context.Occupations.Update(occupation);
            await _context.SaveChangesAsync();
            return occupation;
        }
    }
}
