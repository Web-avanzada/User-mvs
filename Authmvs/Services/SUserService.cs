
using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IGenericService;

namespace Service.SUserService
{
public class SUserService : IGenericService<User>
{
    private readonly DataContext _context;

    public SUserService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();

    public async Task<User> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

    public async Task<User> CreateAsync(User entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> UpdateAsync(int id, User entity)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;

        user.UserName = entity.UserName;
        user.UserMail = entity.UserMail;
        user.UserPassword = entity.UserPassword;
        user.UserType = entity.UserType;

        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}


}
