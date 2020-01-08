using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace TestesAPI.Services {
    public class AcessTokenGen : OAuthAuthorizationServerProvider {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
            if(MeninosSeguranca.Autenticar(context.UserName, context.Password)) {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            } else {
                context.SetError("Não autorizado", "Usuário e/ou senha inválidos");
                return;
            }
        }
    }
}