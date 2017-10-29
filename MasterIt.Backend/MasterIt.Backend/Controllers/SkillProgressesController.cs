﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MasterIt.Backend;
using MasterIt.Backend.Models;

namespace MasterIt.Backend.Controllers
{
    public class SkillProgressesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/SkillProgresses?userId
        public IQueryable<SkillProgress> GetSkillProgresses(int userId)
        {
            return db.SkillProgresses.Where(p => p.User.Id == userId);
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