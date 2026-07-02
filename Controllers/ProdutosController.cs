using Microsoft.AspNetCore.Mvc;
using UniGymFitness.Data;
using UniGymFitness.Models;

namespace UniGymFitness.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        public IActionResult Excluir(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}