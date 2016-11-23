using System;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(OwinAuthentication.Startup))]

namespace OwinAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //USADO PRA INTEGRAR O IIS COM O OWIN
            //Microsoft.Owin.Host.SystemWeb

            //segurança do owin
            //Microsoft.Owin.Security

            // PARA TRABALHAR COM COOKIES
            //Microsoft.Owin.Security.Cookies


            //TODOS DEVEM SE LOGAR NA APLICAÇÃO
            //TEM QUE SE AUTENTICAR NA APLICAÇÕA
            GlobalFilters.Filters.Add(new AuthorizeAttribute());

            //ESTAMOS CRIANDO UM MIDDLEWARE
            //ESTE MIDDLWARE SERA RESPONSAVEL POR AUTENTICAR NOSS APLICAÇÕA USANDO COOKIES
            var options = new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookies",
                CookieName = "LGroupCookies",
                LoginPath = new PathString("/Login/Index"),
                Provider = new CookieAuthenticationProvider()
                {
                    //ESTE CARA É RESPONSAVEL POR VERIFICAR SE O USUARIO TROCOU DE PERFIL ENQUANTO ESTV LOGADO E VAI VERIFICAR SE ISSO NO BANCO CSO DESEJE
                    OnValidateIdentity = (x) =>
                    {
                        return Task.FromResult(0);
                    }
                }
            };

            app.UseCookieAuthentication(options);
        }
    }
}
