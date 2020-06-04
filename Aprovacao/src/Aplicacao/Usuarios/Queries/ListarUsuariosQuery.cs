using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Queries
{
    public class ListarUsuariosQuery : IRequest<IList<UsuarioDTO>>
    {
    }

    public class ListarUsuariosQueryHandler : IRequestHandler<ListarUsuariosQuery, IList<UsuarioDTO>>
    {
        private readonly IAplicacaoDbContext _context;
        private readonly IMapper _mapper;

        public ListarUsuariosQueryHandler(IAplicacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<UsuarioDTO>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Login)
                .ToListAsync(cancellationToken);

        }
    }
}
