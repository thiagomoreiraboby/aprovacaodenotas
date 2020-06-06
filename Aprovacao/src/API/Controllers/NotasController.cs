using System;
using System.Collections.Generic;
using System.Linq;
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
            if (idUsuario == null || idUsuario == Guid.Empty)
                return new List<NotadeCompraDTO>();
            return await Mediator.Send(new ListarNotasparaAprovacaoQuery { IdUsuario = idUsuario, DataInicio = dataIncio, DataFim = dataFim });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Post([FromBody] AutorizacaoNotasCommand command)
        {
            if (command.IdUsuario == Guid.Empty || command.IdNota == Guid.Empty)
                return BadRequest(new { message = "Parametros incorretos!" });
            return await Mediator.Send(command);
        }
    }
}
