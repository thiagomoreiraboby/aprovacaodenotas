using Dominio.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Infra.Interfaces.Persistencia
{
    public class AplicacaoDbContextDadosIniciais
    {

        public static async Task DadosIniciais(AplicacaoDbContext context)
        {
            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario("admin", "admin", 0M, 0M, Dominio.Enums.PapelAprovacao.Adm));
                context.Usuarios.Add(new Usuario("Visto1", "123", 0M, 1000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("Visto2", "123", 1001M, 10000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("Visto3", "123", 10001M, 50000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("Visto4", "123", 50001M, 999999.99M, Dominio.Enums.PapelAprovacao.Visto));

                context.Usuarios.Add(new Usuario("Aprovador1", "123", 0M, 1000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("Aprovador2", "123", 1001M, 10000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("Aprovador3", "123", 10001M, 50000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("Aprovador4", "123", 50001M, 999999.99M, Dominio.Enums.PapelAprovacao.Visto));
            }

            if (!context.AutorizacaoConfigs.Any())
            {
                context.AutorizacaoConfigs.Add(new AutorizacaoConfig(0M, 1000M, 1, 0));
                context.AutorizacaoConfigs.Add(new AutorizacaoConfig(1001M, 10000M, 1, 1));
                context.AutorizacaoConfigs.Add(new AutorizacaoConfig(10001M, 50000M, 2, 1));
                context.AutorizacaoConfigs.Add(new AutorizacaoConfig(50001M, 999999.99M, 2, 2));
            }

            if (!context.NotadeCompras.Any())
            {
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now, 998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now, 9998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now, 49998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now, 999998.99M, 1M, 1M));
            }

            await context.SaveChangesAsync();

        }
    }
}
