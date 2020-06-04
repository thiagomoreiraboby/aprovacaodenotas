using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Interfaces.Configuracao
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(t => t.Login)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Senha)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
