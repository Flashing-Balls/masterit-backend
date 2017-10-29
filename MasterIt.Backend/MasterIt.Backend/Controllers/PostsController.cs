using MasterIt.Backend.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MasterIt.Backend.Controllers
{
    public class PostsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Posts/userId
        [HttpGet]
        public IQueryable<Post> GetPosts(int userId)
        {
            var interests = db.Interests.Where(i => i.UserId == userId).Select(i => i.Id);

            return db.Posts.Include(p => p.Comments).Include(p => p.Skill).Include(d => d.User).Where(x => x.User.Id != userId && interests.Contains(x.Skill.SportId));
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