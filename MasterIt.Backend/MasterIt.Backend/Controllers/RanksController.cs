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
    public class RanksController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Ranks
        public IQueryable<Rank> GetRanks()
        {
            return db.Ranks;
        }

        // GET: api/Ranks/5
        [ResponseType(typeof(Rank))]
        public IHttpActionResult GetRank(int id)
        {
            Rank rank = db.Ranks.Find(id);
            if (rank == null)
            {
                return NotFound();
            }

            return Ok(rank);
        }

        // PUT: api/Ranks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRank(int id, Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rank.Id)
            {
                return BadRequest();
            }

            db.Entry(rank).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankExists(id))
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

        // POST: api/Ranks
        [ResponseType(typeof(Rank))]
        public IHttpActionResult PostRank(Rank rank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ranks.Add(rank);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rank.Id }, rank);
        }

        // DELETE: api/Ranks/5
        [ResponseType(typeof(Rank))]
        public IHttpActionResult DeleteRank(int id)
        {
            Rank rank = db.Ranks.Find(id);
            if (rank == null)
            {
                return NotFound();
            }

            db.Ranks.Remove(rank);
            db.SaveChanges();

            return Ok(rank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RankExists(int id)
        {
            return db.Ranks.Count(e => e.Id == id) > 0;
        }
    }
}