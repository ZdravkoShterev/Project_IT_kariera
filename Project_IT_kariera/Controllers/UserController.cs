using Microsoft.AspNetCore.Mvc;
using Project_IT_kariera.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Project_IT_kariera.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext appDbContext;

        public UserController(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await appDbContext.Users.ToListAsync();
            return View(users);
        }
    }
}
