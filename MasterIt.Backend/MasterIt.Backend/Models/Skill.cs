using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int SportId { get; set; }
    }
}