using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{
    public class User
    {
        public User()
        {

        }

        public User(string Username, string Password, int UserStudent, int UserTutor)
        {
            this.Username = Username;
            this.Password = Password;
            this.UserStudent = UserStudent;
            this.UserTutor = UserTutor;
        }

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
      
        [Required]
        public int UserStudent { get; set; }

        [Required]
        public int  UserTutor { get; set; }

    }
}