using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{

    public class OccupationUser
    {
        [Key]
        public int OccupationTutorId { get; set; }

        public int UserProfilesId { get; set; }
        public int OccupationId { get; set; }

        [ForeignKey("UserProfilesId")]
        public UserProfile UserProfile { get; set; }

        [ForeignKey("OccupationId")]
        public Occupation Occupation { get; set; }

        public OccupationUser() { }

        public OccupationUser(int occupationTutorId, int userProfilesId, int occupationId)
        {
            OccupationTutorId = occupationTutorId;
            UserProfilesId = userProfilesId;
            OccupationId = occupationId;
        }
    }

}