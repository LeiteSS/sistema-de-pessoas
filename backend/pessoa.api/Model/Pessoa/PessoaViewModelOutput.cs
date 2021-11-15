using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.api.Model.Pessoa
{
    public class PessoaViewModelOutput
    {
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int NumeroTelefone { get; set; }
        public int Ddd { get; set; }
        public string Tipo { get; set; }
    }
}
