using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Models;
using Aplicacao.NotadeAprovacao.Commands;
using Aplicacao.NotadeAprovacao.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class NotasController : ApiControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IList<NotadeCompraDTO>> Get(Guid idUsuario, DateTime? dataIncio, DateTime? dataFim)
        {
            return await Mediator.Send(new ListarNotasparaAprovacaoQuery { IdUsuario = idUsuario, DataInicio = dataIncio, DataFim = dataFim });
        }

        [HttpPost]
        [Authorize]
        public async Task<bool> Post(Guid idUsuario, Guid idNota)
        {
            return await Mediator.Send(new AutorizacaoNotasCommand { IdUsuario = idUsuario,IdNota = idNota });
        }
    }
}
