using MasterIt.Backend.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MasterIt.Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [ResponseType(typeof(User))]
        [Route("api/Users/{username}")]
        public IHttpActionResult GetUser(string username)
        {
            User user = db.Users
                .Include(u => u.Rank)
                .Include(u => u.Skills)
                .SingleOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("api/Users/{userId}/posts")]
        public IQueryable<Post> GetUserPosts(int userId)
        {
            return db.Posts
                .Include(p => p.Skill)
                .Include(p => p.User)
                .Where(p => p.User.Id == userId);
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