using System;
using System.ComponentModel.DataAnnotations;

namespace MasterIt.Backend.Models
{
    public class SkillProgress
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int Progress { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}