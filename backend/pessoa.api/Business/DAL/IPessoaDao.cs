using pessoa.api.Business.Entity;
using pessoa.api.Model.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.api.Business.DAL
{
    public interface IPessoaDao
    {
        void Cadastrar(Pessoa p, Endereco e, Telefone t, TipoTelefone tt);
        void Atualizar(long cpf, Pessoa p, Endereco e, Telefone t, TipoTelefone tt);
        void Deletar(long cpf);
        Task<PessoaViewModelOutput> ObterPessoa(long cpf);
    }
}
