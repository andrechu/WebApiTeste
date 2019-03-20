using System;
using System.Web.Http;
using CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Services;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(csc.padrao.light.api.Startup))]

namespace csc.padrao.light.api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            AtivandoAccessTokens(app);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        private void AtivandoAccessTokens(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/auth/v1/token"),

                AccessTokenExpireTimeSpan = TimeSpan.FromHours(4),
                Provider = new TokenApplicationService()
            };
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
