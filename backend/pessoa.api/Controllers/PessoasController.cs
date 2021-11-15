using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pessoa.api.Business.DAL;
using pessoa.api.Business.Entity;
using pessoa.api.Model.Pessoa;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace pessoa.api.Controllers
{
    [Route("api/v1/pessoas")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaDao _pessoaDao;
        private readonly ILogger<PessoasController> _logger;

        public PessoasController(IPessoaDao pessoaDao, ILogger<PessoasController> logger)
        {
            _pessoaDao = pessoaDao;
            _logger = logger;
        }


        /// <summary>
        /// Este serviço permite cadastrar uma pessoa.
        /// </summary>
        /// <returns>Retorna status 201 e dados da pessoa</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar uma pessoa", Type = typeof(PessoaViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos Invalidos")]
        [SwaggerResponse(statusCode: 500, description: "Erro no servidor")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostPessoa(PessoaViewModelInput pessoaViewModelInput)
        {

            try
            {
                Endereco endereco = new Endereco
                {
                    Logradouro = pessoaViewModelInput.Logradouro,
                    Numero = pessoaViewModelInput.Numero,
                    Cep = pessoaViewModelInput.Cep,
                    Bairro = pessoaViewModelInput.Bairro,
                    Cidade = pessoaViewModelInput.Cidade,
                    Estado = pessoaViewModelInput.Estado,
                };


                Pessoa pessoa = new Pessoa
                {
                    Nome = pessoaViewModelInput.Nome,
                    Cpf = pessoaViewModelInput.Cpf,
                };


                Telefone telefone = new Telefone
                {
                    Numero = pessoaViewModelInput.NumeroTelefone,
                    Ddd = pessoaViewModelInput.Ddd,
                };

                TipoTelefone tipoTelefone = new TipoTelefone
                {
                    Tipo = pessoaViewModelInput.Tipo,
                };

                _pessoaDao.Cadastrar(pessoa, endereco, telefone, tipoTelefone);

                var pessoaViewModelOutput = new PessoaViewModelOutput
                {
                    Nome = pessoa.Nome,
                    Cpf = pessoa.Cpf,
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero,
                    Cep = endereco.Cep,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado,
                    NumeroTelefone = telefone.Numero,
                    Ddd = telefone.Ddd,
                    Tipo = tipoTelefone.Tipo,
                };

                return Created("", pessoaViewModelOutput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite obter uma pessoa usando o cpf dela
        /// </summary>
        /// <returns>Retorna status ok e dados da pessoa consultada</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter as consultas", Type = typeof(PessoaViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("/{cpf}")]
        public async Task<IActionResult> GetPessoa(long cpf)
        {
            var pessoaConsultada = _pessoaDao.ObterPessoa(cpf);

            return Ok(pessoaConsultada);
        }

        /// <summary>
        /// Este serviço permite atualizar uma pessoa.
        /// </summary>
        /// <returns>Retorna status 201 e dados da pessoa</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao atualizar uma pessoa", Type = typeof(AtualizarPessoaViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos Invalidos")]
        [SwaggerResponse(statusCode: 500, description: "Erro no servidor")]
        [HttpPut]
        [Route("/{cpf}")]
        public async Task<IActionResult> PutPessoa(long cpf, AtualizarPessoaViewModelInput pessoaViewModelInput)
        {

            try
            {
                Endereco endereco = new Endereco
                {
                    Logradouro = pessoaViewModelInput.Logradouro,
                    Numero = pessoaViewModelInput.Numero,
                    Cep = pessoaViewModelInput.Cep,
                    Bairro = pessoaViewModelInput.Bairro,
                    Cidade = pessoaViewModelInput.Cidade,
                    Estado = pessoaViewModelInput.Estado,
                };


                Pessoa pessoa = new Pessoa
                {
                    Nome = pessoaViewModelInput.Nome,
                    Cpf = cpf,
                };


                Telefone telefone = new Telefone
                {
                    Numero = pessoaViewModelInput.NumeroTelefone,
                    Ddd = pessoaViewModelInput.Ddd,
                };

                TipoTelefone tipoTelefone = new TipoTelefone
                {
                    Tipo = pessoaViewModelInput.Tipo,
                };

                _pessoaDao.Atualizar(cpf, pessoa, endereco, telefone, tipoTelefone);

                var pessoaViewModelOutput = new PessoaViewModelOutput
                {
                    Nome = pessoa.Nome,
                    Cpf = cpf,
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero,
                    Cep = endereco.Cep,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado,
                    NumeroTelefone = telefone.Numero,
                    Ddd = telefone.Ddd,
                    Tipo = tipoTelefone.Tipo,
                };

                return Created("", pessoaViewModelOutput);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Este serviço permite deletar uma pessoa usando o cpf dela
        /// </summary>
        /// <returns>Retorna status ok</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter as consultas", Type = typeof(PessoaViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpDelete]
        [Route("/{cpf}")]
        public async Task<IActionResult> DeletarPessoa(long cpf)
        {
            _pessoaDao.Deletar(cpf);

            return Ok();
        }
    }
}
