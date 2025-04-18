using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{


    public class UserProfile
    {
        [Key]
        public int UserProfilesId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Mail { get; set; }

        public bool Status { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public UserProfile() { }

        public UserProfile(int userProfilesId, int userId, DateTime createDate, string name, string address, string phone, string mail, bool status)
        {
            UserProfilesId = userProfilesId;
            UserId = userId;
            CreateDate = createDate;
            Name = name;
            Address = address;
            Phone = phone;
            Mail = mail;
            Status = status;
        }
    }


}