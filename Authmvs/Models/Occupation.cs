using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsUsers.Users
{

    public class Occupation
    {
        [Key]
        public int OccupationId { get; set; }

        [MaxLength(30)]
        public string OccupationName { get; set; }

        public Occupation() { }

        public Occupation(int occupationId, string occupationName)
        {
            OccupationId = occupationId;
            OccupationName = occupationName;
        }
    }
}