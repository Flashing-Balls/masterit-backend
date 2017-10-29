using System;
using System.Collections.Generic;

namespace MasterIt.Backend.Models
{
    public class SkillProgressTimeline
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int Progress { get; set; }
        public DateTime CompletedOn { get; set; }
        public List<Post> Posts { get; set; }
    }
}