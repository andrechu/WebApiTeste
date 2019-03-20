using csc.padrao.light.core.model.data.repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Services
{
    public class TokenApplicationService : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            => context.Validated();

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //var usuarioRepository = new UsuarioRepository(new csc.padrao.light.core.model.data.contexts.CscContext());
            //var usuario = usuarioRepository.Listar(x => x.DesLoginUsuario == context.UserName && x.DesSenhaUsuario == context.Password);
            var usuario = TokenRepository.Usuarios().FirstOrDefault(x => x.DesLoginUsuario == context.UserName && x.DesSenhaUsuario == context.Password);
            if (usuario == null)
            {
                context.SetError("invalid_grant", "Dados Inválidos.");
                return;
            }
            var identidadeUsuario = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identidadeUsuario);
        }
    }
}

