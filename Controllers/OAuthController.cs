using ASP_API.Attributes;
using ASP_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ASP_API.Controllers
{
    [Route("api/auth")]
    public class OAuthController : Controller
    {
        [HttpPost(), BasicAuthentication]
        public async Task<ActionResult<Users>> Token()
        {
            return Ok();
        }
    }
}
