using Microsoft.AspNetCore.Mvc;
using UniGymFitness.Data;
using UniGymFitness.Models;

namespace UniGymFitness.Controllers
{
    public class PlanosController : Controller
    {
        private readonly AppDbContext _context;

        public PlanosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var planos = _context.Planos.ToList();
            return View(planos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Plano plano)
        {
            _context.Planos.Add(plano);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var plano = _context.Planos.Find(id);

            if (plano == null)
                return NotFound();

            return View(plano);
        }

        [HttpPost]
        public IActionResult Editar(Plano plano)
        {
            if (ModelState.IsValid)
            {
                _context.Planos.Update(plano);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(plano);
        }

        public IActionResult Excluir(int id)
        {
            var plano = _context.Planos.Find(id);

            if (plano == null)
                return NotFound();

            _context.Planos.Remove(plano);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}