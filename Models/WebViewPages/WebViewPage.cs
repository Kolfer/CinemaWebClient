using CinemaWebClient.Models.Identity;
using System.Web.Mvc;
using System.Web;
using System.Security.Claims;

namespace CinemaWebClient.Models.WebViewPages
{
    public abstract class BaseViewPage : WebViewPage
    {
        //----------------------------------------------------------------//

        public virtual new ClaimsPrincipal User
        {
            get { return HttpContext.Current.User as ClaimsPrincipal; }
        }

        //----------------------------------------------------------------//

    }

    //----------------------------------------------------------------//

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {

        //----------------------------------------------------------------//

        public virtual new ClaimsPrincipal User
        {
            get { return HttpContext.Current.User as ClaimsPrincipal; }
        }

        //----------------------------------------------------------------//

        public string Name
        {
            get { return (HttpContext.Current.User as ClaimsPrincipal)
                        ?.FindFirst(ClaimTypes.Name).Value; }
        }

        //----------------------------------------------------------------//

        public string BearerToken
        {
            get {
                return (HttpContext.Current.User as ClaimsPrincipal)
                      ?.FindFirst(Constans.accessToken).Value;
            }
        }

        //----------------------------------------------------------------//

    }
    
}