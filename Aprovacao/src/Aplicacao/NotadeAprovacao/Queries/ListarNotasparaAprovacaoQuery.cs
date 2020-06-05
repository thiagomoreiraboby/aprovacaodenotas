using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Enums;
using MediatR;
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
            var usuario = _context.Usuarios.Where(x => x.Id == request.IdUsuario).SingleOrDefault();

            var listadenotas = _context.NotadeCompras.Where(GetQuery(request)).ToList();

            foreach (var nota in listadenotas)
            {
                if (nota.ValorTotal > usuario.ValorMaxino || nota.ValorTotal < usuario.ValorMinimo)
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

        private static Expression<Func<NotadeCompra, bool>> GetQuery(ListarNotasparaAprovacaoQuery request)
        {
            return x => request.DataInicio != null && request.DataFim != null 
            ? x.DataEmissao >= request.DataInicio && x.DataEmissao <= request.DataFim && x.Status == StatusNota.Pendente
            : x.Status == StatusNota.Pendente;
        }
    }
}
