using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.StudentTests;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsTestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsTestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentTest>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{StudentId}")]
        public async Task<ActionResult<List<StudentTest>>> ListByStudent(Guid StudentId,CancellationToken ct)
        {
            return await _mediator.Send(new ListByStudent.Query{studentId=StudentId},ct);
        }

        [HttpGet("{StudentId}")]
        public async Task<ActionResult<List<StudentTest>>> ListByStudent2(Guid StudentId,CancellationToken ct)
        {
            return await _mediator.Send(new ListByStudent2.Query{studentId=StudentId},ct);
        }
        public async Task<ActionResult<List<StudentTest>>> ListByGroupAndStudent(Guid groupID, Guid studentId, CancellationToken ct)
        {
            return await _mediator.Send(new ListByGroupAndStudent.Query { groupId = groupID, studentId = studentId }, ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTest>> Details(Guid id,CancellationToken ct)
        {
            return await _mediator.Send(new Details.Query { Id = id },ct);
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