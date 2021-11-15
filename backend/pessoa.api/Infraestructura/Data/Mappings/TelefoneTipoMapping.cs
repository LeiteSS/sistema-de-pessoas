using pessoa.api.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace pessoa.api.Infraestructura.Data.Mappings
{
    public class TelefoneTipoMapping : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.ToTable("TELEFONE_TIPO");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Tipo);
        }
    }
}
