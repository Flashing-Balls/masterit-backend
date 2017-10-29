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
    public class SportsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Sports/5
        [ResponseType(typeof(Sport))]
        public IHttpActionResult GetSport(int id)
        {
            Sport sport = db.Sports
                .Include(s => s.Skills)
                .SingleOrDefault(s => s.Id == id);
            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SportExists(int id)
        {
            return db.Sports.Count(e => e.Id == id) > 0;
        }
    }
}