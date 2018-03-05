using CinemaWebClient.Models.Identity;
using System.Security.Principal;
using System.Web;

namespace CinemaWebClient.Models.Identity
{
    public class CustomPrincipal : ICustomPrincipal
    {
       public string UserName { get; set; }

        public IIdentity Identity { get; private set; }


        //----------------------------------------------------------------//

        public CustomPrincipal(string userName)
        {
            UserName = userName;
            Identity = new CustomIdentity(userName);
        }

        //----------------------------------------------------------------//

        public bool IsInRole(string role)
        {
            return false;
        }

        //----------------------------------------------------------------//

        public void LogOut()
        {
            var context = HttpContext.Current;
            context?.Request.Cookies.Remove(Constans.userName);
        }

        //----------------------------------------------------------------//

        public void Online()
        {
            if (Identity.IsAuthenticated)
            {
                var statusCode = ClientService.Online(UserName);
            }
        }

        //----------------------------------------------------------------//

        public void Offline()
        {
            if (Identity.IsAuthenticated)
            {
                var statusCode = ClientService.Offline(UserName);
            }
        }

        //----------------------------------------------------------------//
    }
}