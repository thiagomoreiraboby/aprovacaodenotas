using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Commands
{
    public class DeleteUsuarioCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand>
    {
        private readonly IAplicacaoDbContext _context;
        private readonly IMapper _mapper;

        public DeleteUsuarioCommandHandler(IAplicacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {

            var entidade = await _context.Usuarios
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entidade == null)
            {
                throw new Exception($"{nameof(Usuario)}, {request.Id}");
            }
            _context.Usuarios.Remove(entidade);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
