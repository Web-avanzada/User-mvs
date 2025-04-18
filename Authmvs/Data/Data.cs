
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
         public DbSet<UserProfile> UserProfiles { set; get; }
         public DbSet<UserSchedule> UserSchedules { set; get; }
        public DbSet<Theme> Themes { set; get; }
        public DbSet<ThemeUser> ThemeUsers { set; get; }
        public DbSet<Occupation> Occupations { set; get; }
         public DbSet<OccupationUser> OccupationUsers { set; get; }



    }
}