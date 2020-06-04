using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Models;
using Aplicacao.Usuarios.Commands;
using Aplicacao.Usuarios.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsuarioController : ApiControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> Get(Guid id)
        {
            return await Mediator.Send(new ListarUsuariosPorIDQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CriarUsuarioCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IList<UsuarioDTO>> Get()
        {
            return await Mediator.Send(new ListarUsuariosQuery());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Put(Guid id, UpdateUsuarioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteUsuarioCommand { Id = id });
            return NoContent();
        }
    }
}
