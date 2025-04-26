using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{

    public class OccupationUser
    {
        [Key]
        public int OccupationTutorId { get; set; }

        
  

        [ForeignKey("UserProfilesId")]
        public int UserProfilesId { get; set; }

        [ForeignKey("OccupationId")]
          public int OccupationId { get; set; }

        public OccupationUser() { }

        public OccupationUser(int occupationTutorId, int userProfilesId, int occupationId)
        {
            OccupationTutorId = occupationTutorId;
            UserProfilesId = userProfilesId;
            OccupationId = occupationId;
        }
    }

}