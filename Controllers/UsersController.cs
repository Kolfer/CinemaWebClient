using CinemaWebClient.Models;
using System.Web.Mvc;
using System.Threading.Tasks;
using CinemaWebClient.Models.Identity;

namespace CinemaWebClient.Controllers
{
    [RoutePrefix("User")]
    public class UsersController : BaseController
    {

        public UsersController(IUserSession userSession)
            : base(userSession)
        {}

        //----------------------------------------------------------------//

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult> Users(string name)
        {
            var userView = await ClientService.getUser(name);
            ViewBag.IsFriend = UserSession.UserName != name
                               ? await ClientService.IsFriend(UserSession.UserName, name)
                               : RelationsUsers.SameUser;
            return View(userView);
        }

        //----------------------------------------------------------------//

        [HttpGet]
        [Route("{name}/Friends")]
        public ActionResult Friends(string name)
        {
            return View((object)name);
        }

        //----------------------------------------------------------------//

        [HttpGet]
        [Route("~Chat/{ChatId}")]
        public async Task<ActionResult> Chat(int ChatId)
        {
            var chat = await ClientService.Chat(ChatId);
            return View(chat);
        }

        //----------------------------------------------------------------//

    }
}