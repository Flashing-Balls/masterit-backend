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
    public class SkillsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Skills
        public IQueryable<Skill> GetSKills()
        {
            return db.SKills;
        }

        // GET: api/Skills/5
        [ResponseType(typeof(Skill))]
        public IHttpActionResult GetSkill(int id)
        {
            Skill skill = db.SKills.Find(id);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkill(int id, Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skill.Id)
            {
                return BadRequest();
            }

            db.Entry(skill).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skills
        [ResponseType(typeof(Skill))]
        public IHttpActionResult PostSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SKills.Add(skill);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(Skill))]
        public IHttpActionResult DeleteSkill(int id)
        {
            Skill skill = db.SKills.Find(id);
            if (skill == null)
            {
                return NotFound();
            }

            db.SKills.Remove(skill);
            db.SaveChanges();

            return Ok(skill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillExists(int id)
        {
            return db.SKills.Count(e => e.Id == id) > 0;
        }
    }
}