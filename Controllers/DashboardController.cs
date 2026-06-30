using Microsoft.AspNetCore.Mvc;
using UniGymFitness.Data;

namespace UniGymFitness.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalUsuarios = _context.Usuarios.Count();

            return View();
        }
    }
}