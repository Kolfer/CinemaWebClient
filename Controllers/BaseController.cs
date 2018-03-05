using AuthecantionWithCookie.Abstract;
using AuthecantionWithCookie.Concrete;
using System.Security.Principal;
using System.Web.Mvc;
using CinemaWebClient.Models.Identity;

namespace CinemaWebClient.Controllers
{
    public class BaseController : Controller
    {

        //----------------------------------------------------------------//

        protected IUserSession UserSession;

        //----------------------------------------------------------------//

        public BaseController(IUserSession userSession)
        {
            UserSession = userSession;
        }

        //----------------------------------------------------------------//

    }
}