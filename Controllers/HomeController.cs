using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using System.Diagnostics;
using System.Linq;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        // Inject ApplicationDbContext
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Index Action
        public IActionResult Index()
        {
            // Hämta data från databasen
            var skills = _context.Skills.ToList(); // Hämta alla Skills
            var frameworks = _context.FrameworksModel.ToList(); // Hämta alla Frameworks
            var courses = _context.Courses.ToList(); //Hämta Courses

            // Skapa en ViewModel som innehåller båda listorna
            var viewModel = new HomeViewModel
            {
                Skills = skills,
                Frameworks = frameworks,
                Courses = courses
            };

            // Skicka ViewModel till vyn
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
