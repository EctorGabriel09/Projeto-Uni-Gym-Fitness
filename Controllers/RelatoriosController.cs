using Microsoft.AspNetCore.Mvc;
using UniGymFitness.Data;

namespace UniGymFitness.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tipoUsuario = HttpContext.Session.GetString("TipoUsuario");

            if (tipoUsuario != "Administrador")
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.TotalUsuarios = _context.Usuarios.Count();
            ViewBag.TotalAlunos = _context.Usuarios.Count(u => u.TipoUsuario == "Aluno");
            ViewBag.TotalAdministradores = _context.Usuarios.Count(u => u.TipoUsuario == "Administrador");
            ViewBag.TotalPlanos = _context.Planos.Count();
            ViewBag.TotalProdutos = _context.Produtos.Count();

            ViewBag.TotalEstoque = _context.Produtos.Any()
                ? _context.Produtos.Sum(p => p.Estoque)
                : 0;

            ViewBag.ValorMedioPlanos = _context.Planos.Any()
                ? _context.Planos.Average(p => p.Preco)
                : 0;

            return View();
        }
    }
}