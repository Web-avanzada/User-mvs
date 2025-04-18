using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{

    public class UserSchedule
    {
        [Key]
        public int UserScheduleId { get; set; }

        public int UserProfilesId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("UserProfilesId")]
        public UserProfile UserProfile { get; set; }

        public UserSchedule() { }

        public UserSchedule(int userScheduleId, int userProfilesId, DateTime date, DateTime startTime, DateTime endTime)
        {
            UserScheduleId = userScheduleId;
            UserProfilesId = userProfilesId;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}