using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Interfaces.Configuracao
{
    public class AutorizacaoConfigConfiguracao : IEntityTypeConfiguration<AutorizacaoConfig>
    {
        public void Configure(EntityTypeBuilder<AutorizacaoConfig> builder)
        {
           
        }
    }
}
