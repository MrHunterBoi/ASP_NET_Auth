using ASP_API.Attributes;
using ASP_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using SQLitePCL;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using ASP_API;
using ASP_API.Controllers;

namespace ASP_API.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, HospitalDBContext context) : base(options, logger, encoder, clock)
        {

            _context = context;
            users = context.Users.ToList();
        }

        public HospitalDBContext _context;
        public List<Users> users;

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(
                    AuthenticateResult.Fail("Missing authorization key"
                    ));
            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();

            if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(
                    AuthenticateResult.Fail("Autnorization header does not contain 'Basic' "
                    ));
            }

            var authBase64Decoded = Encoding.UTF8.GetString(Convert.FromBase64String(
                authorizationHeader.Replace("Basic ","",StringComparison.OrdinalIgnoreCase
                )));
            var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);

            if(authSplit.Length != 2) 
            {
                return Task.FromResult(
                   AuthenticateResult.Fail("AuthSplit is not 2"
                   ));
            }

            var clientId = authSplit[0];
            var clientSecret = authSplit[1];


            bool valid = false;
            foreach(var user in users)
            {
                if(clientId == user.UserName && clientSecret == user.Password)
                {
                    valid = true;
                }
            }

            if(!valid)
            {
                return Task.FromResult(
                    AuthenticateResult.Fail("Autnorization failed. ClientId or ClientSecret is not 'test'  "
                    ));
            }

            var client = new ClientAuthenticationDefaults
            {
                AuthenticationType = "Basic",
                IsAuthenticated = true,
                Name = clientId
            };

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
            {
                new Claim(ClaimTypes.Name, clientId)
            }));

            return Task.FromResult(
                AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, Scheme.Name
                    )
                )
            );
        }
    }
}
