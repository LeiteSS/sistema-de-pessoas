using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.api.Business.Entity
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public List<Telefone> Telefones { get; set; }

        public Pessoa()
        {
            Telefones = new List<Telefone>();
        }
    }
}
