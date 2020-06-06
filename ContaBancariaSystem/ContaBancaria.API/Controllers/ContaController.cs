using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Application;
using ContaBancaria.Core;
using JsonWebToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private IEntityCrudHandler<Conta> handler;
        public ContaController(IEntityCrudHandler<Conta> handler) => this.handler = handler;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientID = int.Parse(((JWTPayload)this.HttpContext.Items["JWTPayload"]).uid);
            var contas = await handler.Listar(clientID);
            return new JsonResult(contas.Select(c => new { c.Agencia.Banco.Name, c.AgenciaID, c.ContaID, c.Saldo }));
        }
    }
}
