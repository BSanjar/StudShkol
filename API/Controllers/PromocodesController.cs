using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Promocodes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PromocodesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PromocodesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Promocode>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Promocode>> Details(Guid id,CancellationToken ct)
        {
            return await _mediator.Send(new Details.Query { Id = id },ct);
        }
        [HttpGet("{code}")]
        public async Task<ActionResult<Promocode>> DetailsByCode(string code,CancellationToken ct)
        {
            return await _mediator.Send(new DetailsByName.Query { code = code },ct);
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command{id = id});
        }

         [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}