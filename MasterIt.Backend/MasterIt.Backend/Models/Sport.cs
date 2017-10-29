using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Skill> Skills { get; set; }
    }
}