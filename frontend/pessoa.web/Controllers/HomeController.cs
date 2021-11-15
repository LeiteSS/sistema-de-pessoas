using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pessoa.web.Models;
using pessoa.web.Models.Pessoa;
using pessoa.web.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        // GET: HomeController/Details/5
        public async Task<IActionResult> List()
        {
            List<PessoaViewModelOutput> output = new List<PessoaViewModelOutput>();
            PessoaViewModelOutput pessoa = new PessoaViewModelOutput
            {
                Id = 1,
                Nome = "Oplaca",
                Cpf = 12345678900,
                Logradouro = "Rua",
                Numero = 1,
                Cep = 12345677,
                Bairro = "Bairro da Rua",
                Cidade = "Cidade do Bairro da Rua",
                Estado = "Estado da cidade do bairro da rua",
                NumeroTelefone = 123445328,
                Ddd = 12,
                Tipo = "Residencial"
            };

            output.Add(pessoa);

            return View(output);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        public async Task<IActionResult> Create(PessoaViewModelInput pessoaViewModelInput)
        {
            List<PessoaViewModelInput> pessoas = new List<PessoaViewModelInput>();
            Random rnd = new Random();

            try
            {
                PessoaViewModelInput pessoa = new PessoaViewModelInput
                {
                    Id = rnd.Next(1, 1000),
                    Nome = pessoaViewModelInput.Nome,
                    Cpf = pessoaViewModelInput.Cpf,
                    Logradouro = pessoaViewModelInput.Logradouro,
                    Numero = pessoaViewModelInput.Numero,
                    Cep = pessoaViewModelInput.Cep,
                    Bairro = pessoaViewModelInput.Bairro,
                    Cidade = pessoaViewModelInput.Cidade,
                    Estado = pessoaViewModelInput.Estado,
                    NumeroTelefone = pessoaViewModelInput.NumeroTelefone,
                    Ddd = pessoaViewModelInput.Ddd,
                    Tipo = pessoaViewModelInput.Tipo
                };

                ModelState.AddModelError("", $"O cadastrado foi realizado com sucesso {pessoa.Nome}");

                pessoas.Add(pessoa);
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(pessoas);
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete()
        {

            return View();
        }
    }
}
