using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{

    public class ThemeUser
    {
        [Key]
        public int ThemeStudentId { get; set; }

        public int UserProfilesId { get; set; }
        public int ThemeId { get; set; }

        [ForeignKey("UserProfilesId")]
        public UserProfile UserProfile { get; set; }

        [ForeignKey("ThemeId")]
        public Theme Theme { get; set; }

        public ThemeUser() { }

        public ThemeUser(int themeStudentId, int userProfilesId, int themeId)
        {
            ThemeStudentId = themeStudentId;
            UserProfilesId = userProfilesId;
            ThemeId = themeId;
        }
    }

}