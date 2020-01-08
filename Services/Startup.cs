using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(TestesAPI.Services.Startup))]

namespace TestesAPI.Services {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888


            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                 name: "DefaultApi",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { id = RouteParameter.Optional }
            );

            AtivarGeracaoTokenAcesso(app); 

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

        }

        private void AtivarGeracaoTokenAcesso(IAppBuilder app) {
            var options = new OAuthAuthorizationServerOptions() {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/autenticar"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new AcessTokenGen()
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
