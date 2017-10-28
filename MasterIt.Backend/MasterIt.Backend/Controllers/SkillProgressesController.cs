using System;
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

        // GET: api/SkillProgresses
        public IQueryable<SkillProgress> GetSkillProgresses()
        {
            return db.SkillProgresses;
        }

        // GET: api/SkillProgresses/5
        [ResponseType(typeof(SkillProgress))]
        public IHttpActionResult GetSkillProgress(int id)
        {
            SkillProgress skillProgress = db.SkillProgresses.Find(id);
            if (skillProgress == null)
            {
                return NotFound();
            }

            return Ok(skillProgress);
        }

        // PUT: api/SkillProgresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkillProgress(int id, SkillProgress skillProgress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skillProgress.Id)
            {
                return BadRequest();
            }

            db.Entry(skillProgress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillProgressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SkillProgresses
        [ResponseType(typeof(SkillProgress))]
        public IHttpActionResult PostSkillProgress(SkillProgress skillProgress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkillProgresses.Add(skillProgress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skillProgress.Id }, skillProgress);
        }

        // DELETE: api/SkillProgresses/5
        [ResponseType(typeof(SkillProgress))]
        public IHttpActionResult DeleteSkillProgress(int id)
        {
            SkillProgress skillProgress = db.SkillProgresses.Find(id);
            if (skillProgress == null)
            {
                return NotFound();
            }

            db.SkillProgresses.Remove(skillProgress);
            db.SaveChanges();

            return Ok(skillProgress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillProgressExists(int id)
        {
            return db.SkillProgresses.Count(e => e.Id == id) > 0;
        }
    }
}