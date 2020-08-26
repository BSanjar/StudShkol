using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.LevelTests;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LevelTestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LevelTestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LevelTest>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<List<LevelTest>>> ListByGroup(Guid groupID, CancellationToken ct)
        {
            return await _mediator.Send(new ListByGroup.Query { groupId = groupID }, ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LevelTest>> Details(Guid id, CancellationToken ct)
        {
            return await _mediator.Send(new Details.Query { Id = id }, ct);
        }
        //[HttpGet("{groupId}&{studentId}")]
        public async Task<ActionResult<List<LevelTest>>> ListLevelsStudent(Guid groupID, Guid studentId, CancellationToken ct)
        {
            return await _mediator.Send(new ListByGroupAndStudent.Query { groupId = groupID, studentId = studentId }, ct);
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