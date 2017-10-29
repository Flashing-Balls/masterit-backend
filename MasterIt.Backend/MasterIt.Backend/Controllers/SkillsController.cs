using MasterIt.Backend.Models;
using System.Linq;
using System.Web.Http;

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