
using Microsoft.EntityFrameworkCore;


using ModelsUsers.Users;

namespace DataDataContext.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       

        public DbSet<User> Users { set; get; }



    }
}