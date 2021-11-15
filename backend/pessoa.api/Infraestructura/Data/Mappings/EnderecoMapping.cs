using pessoa.api.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pessoa.api.Infraestructura.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Logradouro);
            builder.Property(p => p.Numero);
            builder.Property(p => p.Cep);
            builder.Property(p => p.Bairro);
            builder.Property(p => p.Cidade);
            builder.Property(p => p.Estado);
        }
    }
}
