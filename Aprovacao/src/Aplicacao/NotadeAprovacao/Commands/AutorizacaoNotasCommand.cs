using Aplicacao.Interfaces;
using Dominio.Entidades;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.NotadeAprovacao.Commands
{
    public class AutorizacaoNotasCommand : IRequest<bool>
    {
        public Guid IdUsuario { get; set; }
        public Guid IdNota { get; set; }
    }

    public class AutorizacaoNotasCommandHandler : IRequestHandler<AutorizacaoNotasCommand, bool>
    {
        private readonly IAplicacaoDbContext _context;

        public AutorizacaoNotasCommandHandler(IAplicacaoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AutorizacaoNotasCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //await _context.BeginTransactionAsync(cancellationToken);
                var usuario = _context.Usuarios.SingleOrDefault(x => x.Id == request.IdUsuario);
                var nota = _context.NotadeCompras.SingleOrDefault(x => x.Id == request.IdNota);


                _context.AutorizacaoHistoricos.Add(new AutorizacaoHistorico(DateTime.Now, usuario, nota, usuario.Papel));
                

                if (ValidacoeseVerificacoes.VerificarConfiguracaoAutorizacao(_context, nota, usuario.Papel))
                {
                    nota.AprovarNota();
                    _context.NotadeCompras.Update(nota);
                }

                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
            catch (Exception ex)
            {
                //_context.RollbackTransaction();
                return false;
            }

        }
    }



}
