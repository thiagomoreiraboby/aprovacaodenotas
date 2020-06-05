using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Queries
{
    public class ListarUsuariosPorIDQuery : IRequest<UsuarioDTO>
    {
        public Guid Id { get; set; }
    }

    public class ListarUsuariosPorIDQueryHandler : IRequestHandler<ListarUsuariosPorIDQuery, UsuarioDTO>
    {
        private readonly IAplicacaoDbContext _context;
        private readonly IMapper _mapper;

        public ListarUsuariosPorIDQueryHandler(IAplicacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Handle(ListarUsuariosPorIDQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.Where(x=> x.Id == request.Id)
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
