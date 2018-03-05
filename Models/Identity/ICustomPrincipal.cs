using System.Security.Principal;

namespace CinemaWebClient.Models.Identity
{
    interface ICustomPrincipal : IPrincipal
    {
        string UserName { get; set; }
    }
}
