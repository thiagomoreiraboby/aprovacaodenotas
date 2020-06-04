using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Interfaces.Configuracao
{
    public class NotadeCompraConfiguracao : IEntityTypeConfiguration<NotadeCompra>
    {
        public void Configure(EntityTypeBuilder<NotadeCompra> builder)
        {
            
        }
    }
}
