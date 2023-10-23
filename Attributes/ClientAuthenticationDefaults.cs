using System.Security.Principal;

namespace ASP_API.Attributes
{
    public class ClientAuthenticationDefaults : IIdentity
    {
        public string? AuthenticationType { get; set;}

        public bool IsAuthenticated { get; set; }

        public string? Name { get; set; }
    }
}
