using Microsoft.AspNetCore.Mvc;
using PersonTable.Models;
using PersonTable.Repository;

namespace PersonTable.Controllers
{
    public class PessoasEFController : Controller
    {
        private readonly PessoasEFRepository pessoasEFRepository;
        public PessoasEFController()
        {
            pessoasEFRepository = new PessoasEFRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoas = pessoasEFRepository.Listar();

            return View(listaPessoas);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new PessoasEF());
        }

        [HttpPost]
        public ActionResult Cadastrar(Models.PessoasEF pessoasEF)
        {

            if (ModelState.IsValid)
            {
                pessoasEFRepository.Inserir(pessoasEF);

                @TempData["mensagem"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index", "PessoasEF");
            }
            else
            {
                return View(pessoasEF);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var pessoasEF = pessoasEFRepository.Consultar(Id);

            return View(pessoasEF);
        }

        [HttpPost]
        public ActionResult Editar(Models.PessoasEF pessoasEF)
        {
            if (ModelState.IsValid)
            {
                pessoasEFRepository.Alterar(pessoasEF);

                @TempData["mensagem"] = "Cadastro alterado com sucesso!";
                return RedirectToAction("Index", "PessoasEF");
            }
            else
            {
                return View(pessoasEF);
            }

        }

        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var pessoasEF = pessoasEFRepository.Consultar(Id);
            return View(pessoasEF);
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            pessoasEFRepository.Excluir(Id);

            @TempData["mensagem"] = "Cadastro excluído com sucesso!";

            return RedirectToAction("Index", "PessoasEF");
        }

    }
}
