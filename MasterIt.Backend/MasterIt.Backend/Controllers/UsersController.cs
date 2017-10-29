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
using System.Web.Http.Cors;

namespace MasterIt.Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users
                .Include(u => u.Rank)
                .Include(u => u.Skills)
                .SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
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