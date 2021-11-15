using pessoa.web.Models.Pessoa;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.web.Services
{
    public interface IPessoaService
    {
        [Post("/api/v1/pessoas")]
        Task<PessoaViewModelInput> Cadastrar(PessoaViewModelInput pessoaViewModelInput);

        [Get("/api/v1/pessoas/{cpf}")]
        Task<PessoaViewModelOutput> ObterPessoa(long cpf);

        [Post("/api/v1/pessoas/{cpf}")]
        Task<PessoaViewModelOutput> Atualizar(long cpf, AtualizarPessoaViewModelInput pessoaViewModelInput);

        [Delete("/api/v1/pessoas/{cpf}")]
        Task<PessoaViewModelOutput> Deletar(long cpf);
    }
}
