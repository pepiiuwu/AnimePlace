using AnimePlace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimePlace.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> applicationUser;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.applicationUser = userManager;
        }
    }
}
