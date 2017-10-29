using MasterIt.Backend.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MasterIt.Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SportsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Sports
        public IQueryable<Sport> GetSports()
        {
            return db.Sports.Include(s => s.Skills);
        }

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