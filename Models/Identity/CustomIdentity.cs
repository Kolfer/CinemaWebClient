using System.Security.Principal;
using System.Web;
using CinemaWebClient.Models;

namespace CinemaWebClient.Models.Identity
{
    public class CustomIdentity : IIdentity
    {
        public string Name { get; }

        //----------------------------------------------------------------//

        public CustomIdentity(string name)
        {
            Name = name;
        }

        //----------------------------------------------------------------//
           
        public string AuthenticationType
        {
            get { return "Authorized"; } 
        }

        //----------------------------------------------------------------//

        public bool IsAuthenticated
        {
            get
            {
                var context = HttpContext.Current;
                var userName = context?.Request?.Cookies[Constans.userName];
                return userName.Value == Name;
            }
        }

        //----------------------------------------------------------------//


    }
}