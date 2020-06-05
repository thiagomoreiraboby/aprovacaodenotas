using Aplicacao.Common.Mappings;
using AutoMapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Models
{
    public class NotadeCompraDTO : IMapFrom<NotadeCompra>
    {
        public Guid Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public decimal ValorMercadorias { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorTotal => ValorMercadorias + ValorFrete - ValorDesconto;
        public StatusNotaDTO Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NotadeCompra, NotadeCompraDTO>()
                .ForMember(d => d.Status, opt => opt.MapFrom(s => (StatusNotaDTO)s.Status));
        }
    }
}
