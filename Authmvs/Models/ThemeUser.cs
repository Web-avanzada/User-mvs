using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{

    public class ThemeUser
    {
        [Key]
        public int ThemeStudentId { get; set; }

       
      

        [ForeignKey("UserProfilesId")]
        public int UserProfilesId { get; set; }

        [ForeignKey("ThemeId")]
       public int ThemeId { get; set; }

        public ThemeUser() { }

        public ThemeUser(int themeStudentId, int userProfilesId, int themeId)
        {
            ThemeStudentId = themeStudentId;
            UserProfilesId = userProfilesId;
            ThemeId = themeId;
        }
    }

}