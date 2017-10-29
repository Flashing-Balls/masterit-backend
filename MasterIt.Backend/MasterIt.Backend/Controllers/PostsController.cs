﻿using System;
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