using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using CinemaWebClient.Models;

namespace CinemaWebClient.Controllers
{
    [RoutePrefix("People")]
    public class PeopleController : Controller
    {

        //----------------------------------------------------------------//

        [Route("{id:int}")]
        // GET: People
        public async Task<ActionResult> People(int id)
        {
            var people = await ClientService.GetPeople(id);
            return View(people);
        }

        //----------------------------------------------------------------//

    }
}