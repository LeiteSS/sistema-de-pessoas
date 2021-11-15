namespace pessoa.api.Business.Entity
{
    public class Telefone
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Ddd { get; set; }
        public int TipoTelefoneId { get; set; }
        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}