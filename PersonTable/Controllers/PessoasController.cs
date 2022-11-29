using Microsoft.AspNetCore.Mvc;
using PersonTable.Models;
using PersonTable.Repository;

namespace PersonTable.Controllers
{
    public class PessoasController : Controller
    {
        private readonly PessoasRepository pessoasRepository;
        public PessoasController()
        {
            pessoasRepository = new PessoasRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoas = pessoasRepository.Listar();

            return View(listaPessoas);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new Pessoas());
        }

        [HttpPost]
        public ActionResult Cadastrar(Models.Pessoas pessoas)
        {

            if (ModelState.IsValid)
            {
                pessoasRepository.Inserir(pessoas);

                @TempData["mensagem"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index", "Pessoas");
            }
            else
            {
                return View(pessoas);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var pessoas = pessoasRepository.Consultar(Id);

            return View(pessoas);
        }

        [HttpPost]
        public ActionResult Editar(Models.Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                pessoasRepository.Alterar(pessoas);

                @TempData["mensagem"] = "Cadastro alterado com sucesso!";
                return RedirectToAction("Index", "Pessoas");
            }
            else
            {
                return View(pessoas);
            }

        }

        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var pessoas = pessoasRepository.Consultar(Id);
            return View(pessoas);
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            pessoasRepository.Excluir(Id);

            @TempData["mensagem"] = "Cadastro excluído com sucesso!";

            return RedirectToAction("Index", "Pessoas");
        }

    }
}
