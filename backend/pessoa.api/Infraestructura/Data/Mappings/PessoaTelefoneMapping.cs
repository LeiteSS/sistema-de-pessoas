using pessoa.api.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pessoa.api.Infraestructura.Data.Mappings
{
    public class PessoaTelefoneMapping : IEntityTypeConfiguration<PessoaTelefone>
    {
        public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
        {
            builder.ToTable("PESSOA_TELEFONE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(p => p.Pessoa)
                .WithMany().HasForeignKey(fk => fk.PessoaId);
            builder.HasOne(p => p.Telefone)
                .WithMany().HasForeignKey(fk => fk.TelefoneId);
        }
    }
}
