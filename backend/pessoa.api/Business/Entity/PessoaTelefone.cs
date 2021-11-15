using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.api.Business.Entity
{
    public class PessoaTelefone
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public int TelefoneId { get; set; }
        public virtual Telefone Telefone { get; set; }

        public List<Pessoa> Pessoas { get; set; }
        public List<Telefone> Telefones { get; set; }

        public PessoaTelefone()
        {
            Telefones = new List<Telefone>();
            Pessoas = new List<Pessoa>();
        }
    }
}
