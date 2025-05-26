using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{

    public class UserSchedule
    {
        [Key]
        public int UserScheduleId { get; set; }

        
        public DateTime Date { get; set; }
        public TimeSpan  StartTime { get; set; }
        public TimeSpan  EndTime { get; set; }

        [ForeignKey("UserProfilesId")]
       public int UserProfilesId { get; set; }
        public UserSchedule() { }

        public UserSchedule(int userScheduleId, int userProfilesId, DateTime date, TimeSpan  startTime, TimeSpan  endTime)
        {
            UserScheduleId = userScheduleId;
            UserProfilesId = userProfilesId;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}