using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.Identity
{
    public interface IUserSession
    {
        string UserName { get; }

        string BearerToken { get; }
    }
}