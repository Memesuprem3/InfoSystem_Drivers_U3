using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using U3_Infosystem_ASP.NET.Data;


namespace U3_Infosystem_ASP.NET.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employee/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Employee/Login
        public async Task<IActionResult> Login(string email, string password)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == email && e.Password == password);

            if (employee == null)
            {
                ViewBag.ErrorMessage = "Ogiltigt e-post eller lösenord";
                return View();
            }

            // Skapa claims baserat på roll
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, employee.Name),
        new Claim(ClaimTypes.Role, employee.Role)
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return employee.Role == "Admin"
                ? RedirectToAction("AdminOverview")
                : RedirectToAction("DriverOverview");
        }

        // GET: Employee/Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // Exempelmetoder för Admin- och Employee-vyer
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOverview()
        {
            return View(); // Sidan för Admin-översikt
        }

        [Authorize(Roles = "Employee")]
        public IActionResult DriverOverview()
        {
            return View(); // Sidan för hantering av förare och händelser
        }
    }
}