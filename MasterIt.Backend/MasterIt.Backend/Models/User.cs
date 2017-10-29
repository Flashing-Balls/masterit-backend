using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Rank Rank { get; set; }
        public IList<Sport> Sports { get; set; }
        public IList<Skill> Skills { get; set; }
    }
}