using System;
using System.Collections.Generic;
using MasterIt.Backend.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MasterIt.Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Posts/userId
        [HttpGet]
        [Route("api/Posts/{userId}")]
        public IQueryable<IList<Post>> GetPosts(int userId)
        {
            var interests = db.Interests.Where(i => i.UserId == userId).Select(i => i.SportId).ToList();

            var allPosts = db.Posts
                .Include(p => p.Comments)
                .Include(p => p.Skill)
                .Include(d => d.User).ToList();

            return allPosts.Where(x => x.UserId != userId && interests.Contains(x.Skill.SportId)).Select(GetPostCollection).AsQueryable();

            IList<Post> GetPostCollection(Post post)
            {
                var p = new List<Post> { post };

                if (post.IsApproved && !post.IsRatable)
                {
                    p.AddRange(allPosts.FindAll(t => t.UserId == post.UserId && post.SkillId == t.SkillId));
                }

                return p;
            }
        }

        public IQueryable<Post> GetPostsBySkill(int userId, int skillId)
        {
            return db.Posts.Include(p => p.Comments)
                .Include(p => p.Skill)
                .Include(d => d.User).Where(x => x.UserId == userId && x.SkillId == skillId);
        }

        [HttpPost]
        public IHttpActionResult PostData(Post post)
        {
            if (post.User == null || post.Comments == null || post.Date == default(DateTime) ||
                string.IsNullOrEmpty(post.VideoUrl) || post.Skill == null)
            {
                return BadRequest();
            }

            db.Posts.Add(post);
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