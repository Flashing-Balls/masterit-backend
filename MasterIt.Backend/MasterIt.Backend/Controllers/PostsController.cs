using System;
using System.Collections.Generic;
using MasterIt.Backend.Models;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                    p.AddRange(allPosts.FindAll(t => t.UserId == post.UserId && post.SkillId == t.SkillId && post.Id != t.Id));
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

        /*
        [HttpPost]
        public IHttpActionResult PostData()
        {
            var post = new Post();

            using (var reader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                var content = reader.ReadToEnd();

                Trace.WriteLine(content);

                try
                {
                    var json = JObject.Parse(content);

                    //json...
                }
                catch
                {
                    return BadRequest();
                }
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return Ok();
        }*/

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