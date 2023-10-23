using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ASP_API.Attributes
{
    public class BasicAuthentication : AuthorizeAttribute
    {
        public BasicAuthentication() 
        {
            AuthenticationSchemes = "Basic";
        }
    }
}
