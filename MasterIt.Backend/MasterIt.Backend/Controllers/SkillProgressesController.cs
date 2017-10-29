using MasterIt.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace MasterIt.Backend.Controllers
{
    public class SkillProgressesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/SkillProgresses/userId
        [HttpGet]
        [Route("api/SkillProgresses/{userId}")]
        public IQueryable<SkillProgressTimeline> GetSkillProgresses(int userId)
        {
            var skills = db.SkillProgresses
                .Where(p => p.User.Id == userId)
                .Select(p => new SkillProgressTimeline
                {
                    Id = p.Id,
                    CompletedOn = p.CompletedOn,
                    Progress = p.Progress,
                    SkillId = p.SkillId,
                    Skill = p.Skill,
                    UserId = p.UserId,
                    User = p.User
                });

            // screw performance
            foreach (var skill in skills)
            {
                skill.Posts = db.Posts.Where(p => p.User.Id == userId && p.Skill.Id == skill.Id).ToList();
            }

            return skills;
        }

        // PUT: api/SkillProgresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkillProgress(int userId, int skillId, int progress)
        {
            var skillProgress = db.SkillProgresses.SingleOrDefault(p => p.User.Id == userId && p.Skill.Id == skillId);

            if (skillProgress == null)
            {
                skillProgress = new SkillProgress
                {
                    SkillId = skillId,
                    UserId = userId,
                    CompletedOn = DateTime.Now,
                    Progress = progress
                };
                db.Entry(skillProgress).State = EntityState.Added;
            }
            else
            {
                skillProgress.Progress = progress;
                db.Entry(skillProgress).State = EntityState.Modified;
            }

            db.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}