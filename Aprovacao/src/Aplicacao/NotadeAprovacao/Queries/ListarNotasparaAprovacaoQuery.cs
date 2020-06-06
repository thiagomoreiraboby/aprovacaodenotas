using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dominio.Entidades;
using Dominio.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.NotadeAprovacao.Queries
{
    public class ListarNotasparaAprovacaoQuery : IRequest<IList<NotadeCompraDTO>>
    {
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public Guid IdUsuario { get; set; }
    }

    public class ListarNotasparaAprovacaoQueryHandler : IRequestHandler<ListarNotasparaAprovacaoQuery, IList<NotadeCompraDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IAplicacaoDbContext _context;

        public ListarNotasparaAprovacaoQueryHandler(IAplicacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<NotadeCompraDTO>> Handle(ListarNotasparaAprovacaoQuery request, CancellationToken cancellationToken)
        {
            var listaresultado = new List<NotadeCompraDTO>();
            var usuario = _context.Usuarios.SingleOrDefault(x => x.Id == request.IdUsuario);
            if(usuario == null)
                return listaresultado;

            //teste adm
            if (usuario.Papel == PapelAprovacao.Adm)
            {
                listaresultado = await _context.NotadeCompras.ProjectTo<NotadeCompraDTO>(_mapper.ConfigurationProvider).OrderBy(o => o.DataEmissao).ToListAsync(cancellationToken);
                listaresultado.ForEach(x => x.NStatus = x.Status.ToString());

                return listaresultado;
            }



           var listadenotas = _context.NotadeCompras.Where(GetQuery(request, usuario)).OrderBy(o=> o.DataEmissao).ToList();
            
            foreach (var nota in listadenotas)
            {
                if (_context.AutorizacaoHistoricos.Any(x => x.Nota.Id == nota.Id && x.Usuario.Id == usuario.Id))
                   continue;
                var hist = _context.AutorizacaoHistoricos.Where(x => x.Nota.Id == nota.Id).ToList();

                if (ValidacoeseVerificacoes.VerificarConfiguracaoAutorizacaoDiponivel(_context, nota, hist, usuario))
                {
                    listaresultado.Add(_mapper.Map<NotadeCompraDTO>(nota));
                    continue;
                }
            }
            return listaresultado;
        }

        private static Expression<Func<NotadeCompra, bool>> GetQuery(ListarNotasparaAprovacaoQuery request, Usuario usuario)
        {
            return (x =>
                x.Status == StatusNota.Pendente &&
                 (x.ValorTotal >= usuario.ValorMinimo && x.ValorTotal <= usuario.ValorMaxino) &&
                ((request.DataInicio == null && request.DataFim == null) || x.DataEmissao >= request.DataInicio && x.DataEmissao <= request.DataFim)
            );
        }
    }
}
