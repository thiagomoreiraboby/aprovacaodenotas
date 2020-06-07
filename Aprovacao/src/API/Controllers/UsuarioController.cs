using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Models;
using Aplicacao.Usuarios.Commands;
using Aplicacao.Usuarios.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsuarioController : ApiControllerBase
    {

        [HttpPost("Autenticar")]
        public async Task<ActionResult<dynamic>> AutenticarApi([FromBody] LogarUsuariosQuery logarUsuarios)
        {
            var usuario = Mediator.Send(logarUsuarios).Result;
            if(usuario == null)
                return NotFound(
                    new
                    {
                        Mensagem = "Usuário ou senha inválidos.",
                        Erro = true
                    });
            return new
            {
                codigo = usuario.Id,
                nome = usuario.Login,
                tokenapi = Configuracoes.Configuracao.GeneradorToken(usuario),
                papel = usuario.Papel.ToString()

            };
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> Get(Guid id)
        {
            return await Mediator.Send(new ListarUsuariosPorIDQuery { Id = id });
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Post(CriarUsuarioCommand command)
        {
            return await Mediator.Send(command);
        }

        [Authorize]
        [HttpGet]
        public async Task<IList<UsuarioDTO>> Get()
        {
            return await Mediator.Send(new ListarUsuariosQuery());
        }

        [HttpPut("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteUsuarioCommand { Id = id });
            return NoContent();
        }
    }
}
