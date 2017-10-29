using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int SportId { get; set; }
    }
}