using pessoa.api.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pessoa.api.Infraestructura.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Cpf);
            builder.HasOne(p => p.Endereco)
                .WithMany().HasForeignKey(fk => fk.EnderecoId);
        }
    }
}
