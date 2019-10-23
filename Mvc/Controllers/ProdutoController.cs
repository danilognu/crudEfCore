using Microsoft.AspNetCore.Mvc;
using Dados;
using System.Threading.Tasks;
using Dominio.Entidades;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Mvc.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _context.Produtos.Include(p => p.Categoria).ToList();

            return View(produtos);
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();        
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Produto model)
        {
            _context.Produtos.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}