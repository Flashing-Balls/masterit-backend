using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
        public Sport Sport { get; set; }
    }
}