using Aplicacao.Interfaces;
using Aplicacao.Models;
using AutoMapper;
using Dominio.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.Usuarios.Commands
{
    public class CriarUsuarioCommand : UsuarioDTO, IRequest<Guid>
    {
        public string Senha { get; set; }
    }
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Guid>
    {
        private readonly IAplicacaoDbContext _context;
        private readonly IMapper _mapper;

        public CriarUsuarioCommandHandler(IAplicacaoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entidade = new Dominio.Entidades.Usuario(request.Login, request.Senha, request.ValorMinimo, request.ValorMaxino, (PapelAprovacao)request.Papel);
            _context.Usuarios.Add(entidade);

            await _context.SaveChangesAsync(cancellationToken);
            return entidade.Id;
        }
    }
}
