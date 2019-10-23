using Microsoft.AspNetCore.Mvc;
using Dados;
using System.Threading.Tasks;
using Dominio.Entidades;
using System.Linq;


namespace Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();   

            return View(categorias);
        }


        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Categoria modelo)
        {

            if(modelo.Id == 0){
                   _context.Categorias.Add(modelo); 
            }else{
                var categoriaJaSalva = _context.Categorias.First(c => c.Id == modelo.Id);
                categoriaJaSalva.Nome = modelo.Nome;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var categoria = _context.Categorias.First(c => c.Id == id);

            return View("Salvar", categoria);
        }

        public async  Task<IActionResult> Deletar(int id)
        {
            var categoria = _context.Categorias.First(c => c.Id == id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}