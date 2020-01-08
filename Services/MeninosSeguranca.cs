using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestesAPI.Services {
    public class MeninosSeguranca {

        public static bool Autenticar(string login, string senha) {

            using(API_TESTESEntities banco = new API_TESTESEntities()) {
                return banco.USUARIO.Any(x => x.NM_LOGIN.Equals(login, StringComparison.OrdinalIgnoreCase) && x.SENHA == senha);
            }

        }

    }
}