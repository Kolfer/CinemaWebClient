using System.Security.Claims;
using System.Web;


namespace CinemaWebClient.Models.Identity
{
    public class UserSession : IUserSession
    {

        //----------------------------------------------------------------//

        public string UserName
        {
            get {
                return (HttpContext.Current.User as ClaimsPrincipal)
                                   .FindFirst(ClaimTypes.Name).Value;
            }
        }

        //----------------------------------------------------------------//

        public string BearerToken
        {
            get
            {
                return (HttpContext.Current.User as ClaimsPrincipal)
                                   .FindFirst(Constans.accessToken).Value;
            }
        }
        //----------------------------------------------------------------//

    }
}