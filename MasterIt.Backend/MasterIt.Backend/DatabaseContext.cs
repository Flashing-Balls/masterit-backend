using MasterIt.Backend.Models;
using System.Data.Entity;

namespace MasterIt.Backend
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Skill> SKills { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SkillProgress> SkillProgresses { get; set; }
        public DbSet<Interest> Interests { get; set; }
    }
}