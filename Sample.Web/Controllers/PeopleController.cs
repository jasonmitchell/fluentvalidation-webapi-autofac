using System.Web.Http;
using Sample.Web.Models;

namespace Sample.Web.Controllers
{
    public class PeopleController : ApiController
    {
        public IHttpActionResult CreatePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}