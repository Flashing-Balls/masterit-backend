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
    public class PostsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Posts/userId
        [HttpGet]
        public IQueryable<Post> GetPosts(int userId)
        {
            var user = db.Users.Find(userId);

            if (user == null)
            {
                return new Post[0].AsQueryable();
            }

            var interests = user.Sports.Select(s => s.Id).ToArray();

            var r = new Random();

            return db.Posts.Where(x => x.User.Id != userId && interests.Contains(x.Skill.Sport.Id)).OrderBy(x => r.Next());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Any(e => e.Id == id);
        }
    }
}