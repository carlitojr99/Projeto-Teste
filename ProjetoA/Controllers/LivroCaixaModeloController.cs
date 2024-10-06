using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoA.Data;
using ProjetoA.Models;


namespace ProjetoA.Controllers
{
    public class LivroCaixaModeloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivroCaixaModeloController(ApplicationDbContext context)
        {

            _context = context;
        }

          //Utilizar o banco de dados  
        public async Task<IActionResult> Listagem()
        {
           var LivroCaixa = await _context.LivroCaixaModelo.ToListAsync();

           return View(LivroCaixa);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new LivroCaixaModelo());
        }

        [HttpPost]
        public async Task <IActionResult> Cadastrar([FromForm] LivroCaixaModelo caixa)
        {
            if(ModelState.IsValid)
            {
                await _context.LivroCaixaModelo.AddAsync(caixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Listagem));
            }
            else
            {
                return View(caixa);
            }
           
        }

        public IActionResult Atualizar()
        {
            return View();
        }


        public IActionResult Excluir()
        {
            return View();
        }
    }



}
