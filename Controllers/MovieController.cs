using AuthecantionWithCookie.Abstract;
using System.Web.Mvc;
using CinemaWebClient.Models;
using System.Threading.Tasks;

namespace CinemaWebClient.Controllers
{
    [RoutePrefix("Movie")]
    public class MovieController : Controller
    {
        //----------------------------------------------------------------//

        [Route("{id:int}")]
        public async Task<ActionResult> Movie(int id)
        {
            var movie = await ClientService.getMovie(id);
            ViewBag.State = await ClientService.LikeOrWatchMovie(User.Identity.Name, id);
            return View(movie);
        }

        //----------------------------------------------------------------//

        [Route("~/Movies/{genre}")]
        public async Task<ActionResult> MoviesByGenre(string genre, int countMovie, int numberPage)
        {
            var movieByGenre = await ClientService.GetGenre(genre, countMovie, numberPage);
            return View(movieByGenre);
        }

        //----------------------------------------------------------------//
    }
}