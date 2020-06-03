using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class AutorizacaoConfig : EntidadeBase
    {
        public AutorizacaoConfig(decimal valorMinimo, decimal valorMaxino, int qtdeVistos, int qtdeAprovacoes)
        {
            GerarNovoId();
            ValorMinimo = valorMinimo;
            ValorMaxino = valorMaxino;
            QtdeVistos = qtdeVistos;
            QtdeAprovacoes = qtdeAprovacoes;
        }

        public decimal ValorMinimo { get; private set; }
        public decimal ValorMaxino { get; private set; }
        public int QtdeVistos { get; private set; }
        public int QtdeAprovacoes { get; private set; }
    }
}
