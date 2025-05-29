using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{
    public class UserProfile
    {
        [Key]
        public int UserProfilesId { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required] // Added Required based on "Campo requerido"
        [MaxLength(50)]
        public string Name { get; set; } // Corresponds to "Nombres"

        [Required] // Added Required based on "Campo requerido"
        [MaxLength(50)]
        public string LastName { get; set; } // New property for "Apellidos"

        [Required] // Added Required based on "Campo requerido"
        [MaxLength(100)] // Increased max length for address
        public string Address { get; set; } // Corresponds to "Dirección"

        [Required] // Added Required based on "Campo requerido"
        [MaxLength(20)]
        public string Phone { get; set; } // Corresponds to "Teléfono de contacto"

        [Required] // Added Required based on "Campo requerido"
        [MaxLength(50)]
        [EmailAddress] // Added EmailAddress attribute for validation
        public string Mail { get; set; } // Corresponds to "Mail"

        public DateTime? DateOfBirth { get; set; } // New property for "Fecha Nacimiento", nullable

        [MaxLength(255)] // New property for "Ocupación / Intereses"
        public string OccupationInterests { get; set; }

        public bool Status { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public UserProfile() { }

        // Updated constructor to include new fields
        public UserProfile(int userProfilesId, int userId, DateTime createDate, string name, string lastName, string address, string phone, string mail, DateTime? dateOfBirth, string occupationInterests, bool status)
        {
            UserProfilesId = userProfilesId;
            UserId = userId;
            CreateDate = createDate;
            Name = name;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Mail = mail;
            DateOfBirth = dateOfBirth;
            OccupationInterests = occupationInterests;
            Status = status;
        }
    }
}