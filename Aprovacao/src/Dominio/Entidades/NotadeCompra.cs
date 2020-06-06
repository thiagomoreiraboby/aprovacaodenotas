using Dominio.Enums;
using System;

namespace Dominio.Entidades
{
    public class NotadeCompra : EntidadeBase
    {
        
        public NotadeCompra()
        {

        }
        public NotadeCompra(DateTime dataEmissao, decimal valorMercadorias, decimal valorDesconto, decimal valorFrete)
        {
            GerarNovoId();
            DataEmissao = dataEmissao;
            ValorMercadorias = valorMercadorias;
            ValorDesconto = valorDesconto;
            ValorFrete = valorFrete;
            Status = StatusNota.Pendente;
            ValorTotal = ValorMercadorias + ValorFrete - ValorDesconto;
        }

        public DateTime DataEmissao { get; private set; }
        public decimal ValorMercadorias { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public decimal ValorFrete { get; private set; }
        public decimal ValorTotal { get; private set; }
        public StatusNota Status { get; private set; }

        public void AprovarNota()
        {
            Status = StatusNota.Aprovada;
        }

        
    }
}
