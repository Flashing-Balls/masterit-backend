using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public int VideoUrl { get; set; }
        public User User { get; set; }
        public Skill Skill { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}