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

                context.Usuarios.Add(new Usuario("V1", "123", 0M, 1000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("V1.2", "123", 0M, 1000M, Dominio.Enums.PapelAprovacao.Visto));

                context.Usuarios.Add(new Usuario("V2", "123", 1001M, 10000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("V2.2", "123", 1001M, 10000M, Dominio.Enums.PapelAprovacao.Visto));

                context.Usuarios.Add(new Usuario("V3", "123", 10001M, 50000M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("V3.2", "123", 10001M, 50000M, Dominio.Enums.PapelAprovacao.Visto));

                context.Usuarios.Add(new Usuario("V4", "123", 50001M, 999999.99M, Dominio.Enums.PapelAprovacao.Visto));
                context.Usuarios.Add(new Usuario("V4.2", "123", 50001M, 999999.99M, Dominio.Enums.PapelAprovacao.Visto));

                context.Usuarios.Add(new Usuario("A1", "123", 0M, 1000M, Dominio.Enums.PapelAprovacao.Aprovador));
                context.Usuarios.Add(new Usuario("A1.2", "123", 0M, 1000M, Dominio.Enums.PapelAprovacao.Aprovador));

                context.Usuarios.Add(new Usuario("A2", "123", 1001M, 10000M, Dominio.Enums.PapelAprovacao.Aprovador));
                context.Usuarios.Add(new Usuario("A2.2", "123", 1001M, 10000M, Dominio.Enums.PapelAprovacao.Aprovador));

                context.Usuarios.Add(new Usuario("A3", "123", 10001M, 50000M, Dominio.Enums.PapelAprovacao.Aprovador));
                context.Usuarios.Add(new Usuario("A3.2", "123", 10001M, 50000M, Dominio.Enums.PapelAprovacao.Aprovador));

                context.Usuarios.Add(new Usuario("A4", "123", 50001M, 999999.99M, Dominio.Enums.PapelAprovacao.Aprovador));
                context.Usuarios.Add(new Usuario("A4.2", "123", 50001M, 999999.99M, Dominio.Enums.PapelAprovacao.Aprovador));
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
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-10), 998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-20), 997M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-30), 996M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-40), 995M, 1M, 1M));


                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now, 9998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-10), 9998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-20), 9997M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-30), 9996M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-40), 9995M, 1M, 1M));


                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now, 49998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-10), 49998M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-20), 49997M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-30), 49996M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-40), 49999M, 1M, 1M));


                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now, 999998.99M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-10), 999998.99M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-20), 999997.99M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-30), 999996.99M, 1M, 1M));
                context.NotadeCompras.Add(new NotadeCompra(DateTime.Now.AddDays(-40), 999995.99M, 1M, 1M));
            }

            await context.SaveChangesAsync();

        }
    }
}
