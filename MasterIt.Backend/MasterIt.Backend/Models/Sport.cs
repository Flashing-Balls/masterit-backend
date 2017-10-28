using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Skill> Skills { get; set; }
    }
}