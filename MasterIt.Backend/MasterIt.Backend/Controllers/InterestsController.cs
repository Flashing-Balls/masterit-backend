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
    public class InterestsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Interests
        public IQueryable<Interest> GetInterests()
        {
            return db.Interests;
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