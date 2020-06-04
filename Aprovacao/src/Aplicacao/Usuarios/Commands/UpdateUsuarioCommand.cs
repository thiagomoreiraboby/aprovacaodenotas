using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Commands
{
    public class UpdateUsuarioCommand : UsuarioDTO, IRequest<Guid>
    {
        public string Senha { get; set; }
    }
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Guid>
    {
        private readonly IAplicacaoDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IAplicacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entidade = _mapper.Map<Usuario>(request);
            _context.Usuarios.Update(entidade);

            await _context.SaveChangesAsync(cancellationToken);
            return entidade.Id;
        }
    }
}
