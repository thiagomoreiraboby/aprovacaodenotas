using Aplicacao.Interfaces;
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
                await _context.BeginTransactionAsync();
                var usuario = _context.Usuarios.Where(x => x.Id == request.IdUsuario).SingleOrDefault();
                var nota = _context.NotadeCompras.Where(x => x.Id == request.IdNota).SingleOrDefault();


                _context.AutorizacaoHistoricos.Add(new AutorizacaoHistorico(DateTime.Now, usuario, nota, usuario.Papel));
                ;

                if (ValidacoeseVerificacoes.VerificarConfiguracaoAutorizacao(_context, nota))
                {
                    nota.AprovarNota();
                    _context.NotadeCompras.Update(nota);
                }

                await _context.CommitTransactionAsync();
                return true;

            }
            catch (Exception)
            {
                _context.RollbackTransaction();
                return false;
            }

        }
    }



}
