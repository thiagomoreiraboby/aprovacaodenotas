using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.NotadeAprovacao
{
    public class ValidacoeseVerificacoes
    {

        public static bool VerificarConfiguracaoAutorizacao(IAplicacaoDbContext context, NotadeCompra nota, PapelAprovacao papel)
        {
            var autorizacao = context.AutorizacaoHistoricos.Where(x => x.Nota.Id == nota.Id).ToList();

            var nvistos = autorizacao.Where(x => x.Papel == PapelAprovacao.Visto)?.Count() ?? 0;
            var naprovacoes = autorizacao.Where(x => x.Papel == PapelAprovacao.Aprovador)?.Count() ?? 0;


            var config = context.AutorizacaoConfigs.FirstOrDefault(x => x.ValorMinimo <= nota.ValorTotal && x.ValorMaxino >= nota.ValorTotal);

            switch (papel)
            {
                case PapelAprovacao.Visto:
                    nvistos++;
                    break;
                case PapelAprovacao.Aprovador:
                    naprovacoes++;
                    break;
                default:
                    break;
            }
            if (config.QtdeVistos == nvistos && config.QtdeAprovacoes == naprovacoes)
            {
                return true;
            }

            return false;
        }

        public static bool VerificarConfiguracaoAutorizacaoDiponivel(IAplicacaoDbContext context, NotadeCompra nota,IEnumerable<AutorizacaoHistorico> historicos, Usuario usuario)
        {
            if (!historicos.Any() && usuario.Papel == PapelAprovacao.Visto )
                return true;

            

            var config = context.AutorizacaoConfigs.FirstOrDefault(x => x.ValorMinimo <= nota.ValorTotal && x.ValorMaxino >= nota.ValorTotal);
            if (usuario.Papel == PapelAprovacao.Visto)
            {
                var nvistos = historicos.Where(x => x.Papel == PapelAprovacao.Visto)?.Count() ?? 0;
                if (config.QtdeVistos > nvistos)
                {
                    return true;
                }
            }

            if (usuario.Papel == PapelAprovacao.Aprovador)
            {
                var naprovacoes = historicos.Where(x => x.Papel == PapelAprovacao.Aprovador)?.Count() ?? 0;
                if (config.QtdeAprovacoes > naprovacoes)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
