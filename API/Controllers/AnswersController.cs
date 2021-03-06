using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Answers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Answer>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{test}")]
        public async Task<ActionResult<List<Answer>>> listByTest(Guid test, CancellationToken ct)
        {
            return await _mediator.Send(new ListByTest.Query { test = test });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> Details(Guid id, CancellationToken ct)
        {
            return await _mediator.Send(new Details.Query { Id = id }, ct);
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command { id = id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}