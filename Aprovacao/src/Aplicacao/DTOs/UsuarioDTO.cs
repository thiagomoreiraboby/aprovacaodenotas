using Aplicacao.Common.Mappings;
using AutoMapper;
using Dominio.Entidades;
using System;

namespace Aplicacao.Models
{
    public class UsuarioDTO : IMapFrom<Usuario>
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public decimal ValorMinimo { get; set; }
        public decimal ValorMaxino { get; set; }
        public PapelAprovacaoDTO Papel { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Usuario, UsuarioDTO>()
                .ForMember(d => d.Papel, opt => opt.MapFrom(s => (PapelAprovacaoDTO)s.Papel));
        }
    }
}
