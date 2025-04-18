
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{
    public class Theme
    {
        [Key]
        public int ThemeId { get; set; }

        [MaxLength(30)]
        public string ThemeName { get; set; }

        public Theme() { }

        public Theme(int themeId, string themeName)
        {
            ThemeId = themeId;
            ThemeName = themeName;
        }
    }
}