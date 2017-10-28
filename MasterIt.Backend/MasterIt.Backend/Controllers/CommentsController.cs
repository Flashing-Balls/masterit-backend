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
    public class CommentsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Comments/postId
        [HttpGet]
        public IQueryable<Comment> GetComments(int postId)
        {
            return db.Comments.Where(c => c.Post.Id == postId);
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