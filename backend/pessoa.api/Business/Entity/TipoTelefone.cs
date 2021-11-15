using System.Collections.Generic;

namespace pessoa.api.Business.Entity
{
    public class TipoTelefone
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public List<Telefone> Telefones { get; set; }

        public TipoTelefone()
        {
            Telefones = new List<Telefone>();
        }
    }
}