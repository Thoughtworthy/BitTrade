using BitTrade.BLL.Configuration;
using BitTrade.Common.Models;
using BitTrade.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace BitTrade
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Injection
            SimpleInjectorConfiguration.Register(GlobalConfiguration.Configuration);
            AutoMapperConfiguration.Register();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter); // Avoid having XML format
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || authCookie.Value == "")
                return;

            FormsAuthenticationTicket authTicket;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch
            {
                return;
            }

            // Role 
            _accountModel = JsonConvert.DeserializeObject<AccountModel>(authTicket.UserData);
            if (Context.User != null)
            {
                Context.User = new GenericPrincipal(Context.User.Identity, new[] { _accountModel.Role.ToString() });
            }
        }

        protected void Application_PostAuthenticateRequest()
        {
            if (Request.IsAuthenticated)
            {
                var identity = ClaimsPrincipal.Current.Identities.First();

                identity.AddClaims(new List<Claim>
                {
                    new Claim("ID", _accountModel.ID.ToString()),
                    new Claim("FirstName", _accountModel.FirstName),
                    new Claim("LastName", _accountModel.LastName),
                    new Claim("Email", _accountModel.Email),
                    new Claim("ImageURL", _accountModel.ImageURL ?? string.Empty),
                    new Claim("Role", _accountModel.Role.ToString())
                });
            }
        }

        private AccountModel _accountModel;


    }
}
