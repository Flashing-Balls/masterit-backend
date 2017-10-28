using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Rank
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Endorsement { get; set; }
    }
}