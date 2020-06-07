using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoDbContext
    {
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<NotadeCompra> NotadeCompras { get; set; }
        DbSet<AutorizacaoHistorico> AutorizacaoHistoricos { get; set; }
        DbSet<AutorizacaoConfig> AutorizacaoConfigs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    }
}
