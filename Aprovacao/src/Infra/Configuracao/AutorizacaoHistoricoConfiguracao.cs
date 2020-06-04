using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Interfaces.Configuracao
{
    public class AutorizacaoHistoricoConfiguracao : IEntityTypeConfiguration<AutorizacaoHistorico>
    {
        public void Configure(EntityTypeBuilder<AutorizacaoHistorico> builder)
        {

        }
    }
}
