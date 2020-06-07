
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace Infra.Interfaces.Persistencia
{
    public class AplicacaoDbContext : DbContext, IAplicacaoDbContext
    {
        private IDbContextTransaction _currentTransaction;
        public AplicacaoDbContext(DbContextOptions<AplicacaoDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NotadeCompra> NotadeCompras { get; set; }
        public DbSet<AutorizacaoHistorico> AutorizacaoHistoricos { get; set; }
        public DbSet<AutorizacaoConfig> AutorizacaoConfigs { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
                return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
