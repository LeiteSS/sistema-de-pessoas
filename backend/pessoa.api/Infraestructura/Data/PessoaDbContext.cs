using pessoa.api.Infraestructura.Data.Mappings;
using pessoa.api.Business.Entity;

using Microsoft.EntityFrameworkCore;

namespace pessoa.api.Infraestructura.Data
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            modelBuilder.ApplyConfiguration(new TelefoneMapping());
            modelBuilder.ApplyConfiguration(new TelefoneTipoMapping());
            modelBuilder.ApplyConfiguration(new PessoaTelefoneMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefone { get; set; }
    }
}
