using System.Collections.Generic;
using System.Web.Http;

namespace MasterIt.Backend.Controllers
{
    public class PotatoesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "potato01", "potato02" };
        }
    }
}