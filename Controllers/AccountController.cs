using System.Web.Mvc;
using CinemaWebClient.Models;
using System.Net;
using CinemaWebClient.Models.ViewEntities;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System;
using System.Web;
using Newtonsoft.Json;

namespace CinemaWebClient.Controllers
{
    public class AccountController : Controller
    {
        private const string Service = "http://localhost:59901/api";

        //----------------------------------------------------------------//

        [HttpGet]
        public ActionResult SignIn()
        {
            ViewBag.RefUrl = Extension.RedirectUrl(Request.UrlReferrer, HttpContext.Request.Url);
            return View();
        }

        //----------------------------------------------------------------//

        [HttpPost]
        public ActionResult SignIn(TokenView token)
        {
            AuthenticationProperties properties = new AuthenticationProperties();
            properties.IsPersistent = true;
            properties.ExpiresUtc = DateTime.UtcNow.AddSeconds(token.expires_in);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, token.userName),
                new Claim(Constans.accessToken, token.access_token)
            };
            var identity = new ClaimsIdentity(claims, "AppCookie");
            Request.GetOwinContext().Authentication.SignIn(properties, identity);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        //----------------------------------------------------------------//

        public ActionResult Register()
        {
            ViewBag.RefUrl = Extension.RedirectUrl(Request.UrlReferrer, HttpContext.Request.Url);
            return View();
        }


        //----------------------------------------------------------------//

        public ActionResult LogOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //----------------------------------------------------------------//

    }
}