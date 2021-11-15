using pessoa.api.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pessoa.api.Infraestructura.Data.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("TELEFONE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Numero);
            builder.Property(p => p.Ddd);
            builder.HasOne(p => p.TipoTelefone)
                .WithMany().HasForeignKey(fk => fk.TipoTelefoneId);
        }
    }
}
