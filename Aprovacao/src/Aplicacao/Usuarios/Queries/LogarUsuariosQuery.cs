using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Queries
{
    public class LogarUsuariosQuery : IRequest<UsuarioDTO>
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class LogarUsuariosQueryHandler : IRequestHandler<LogarUsuariosQuery, UsuarioDTO>
    {
        private readonly IAplicacaoDbContext _context;
        private readonly IMapper _mapper;

        public LogarUsuariosQueryHandler(IAplicacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Handle(LogarUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.Where(x=> x.Login == request.Login && x.Senha == request.Senha)
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
