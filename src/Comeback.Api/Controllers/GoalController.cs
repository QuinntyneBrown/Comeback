// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Comeback.Core.AggregateModel.GoalAggregate.Commands;
using Comeback.Core.AggregateModel.GoalAggregate.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;


namespace Comeback.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GoalController
{
    private readonly IMediator _mediator;

    public GoalController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet("{goalId}", Name = "GetGoalByIdRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetGoalByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetGoalByIdResponse>> GetById([FromRoute] GetGoalByIdRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.Goal == null)
        {
            return new NotFoundObjectResult(request.GoalId);
        }

        return response;
    }

    [HttpGet("type/{type}", Name = "GetGoalByTypeRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetGoalsByTypeResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetGoalsByTypeResponse>> GetByType([FromRoute] GetGoalsByTypeRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpGet("today", Name = "GetGoalTodayRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetGoalByDateResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetGoalByDateResponse>> GetToday()
    {
        return await _mediator.Send(new GetGoalByDateRequest());
    }

    [HttpGet("relative", Name = "GetGoalRelativeRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetGoalRelativeResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetGoalRelativeResponse>> GetRelative()
    {
        return await _mediator.Send(new GetGoalRelativeRequest());
    }

    [HttpGet("date/{date}", Name = "GetGoalByDateRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetGoalByDateResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetGoalByDateResponse>> GetByDate([FromRoute] GetGoalByDateRequest request)
    {
        return await _mediator.Send(request);
    }


    [HttpGet(Name = "GetGoalsRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetGoalsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetGoalsResponse>> Get()
        => await _mediator.Send(new GetGoalsRequest());

    [HttpPost(Name = "CreateGoalRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateGoalResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateGoalResponse>> Create([FromBody] CreateGoalRequest request)
        => await _mediator.Send(request);

    [HttpGet("page/{pageSize}/{index}", Name = "GetGoalsPageRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetGoalsPageResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetGoalsPageResponse>> Page([FromRoute] GetGoalsPageRequest request)
        => await _mediator.Send(request);

    [HttpPut(Name = "UpdateGoalRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateGoalResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateGoalResponse>> Update([FromBody] UpdateGoalRequest request)
        => await _mediator.Send(request);

    [HttpPut("acheive", Name = "AchieveGoalRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(AchieveGoalResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<AchieveGoalResponse>> Achieve([FromBody] AchieveGoalRequest request)
        => await _mediator.Send(request);

    [HttpDelete("{goalId}", Name = "RemoveGoalRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(RemoveGoalResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<RemoveGoalResponse>> Remove([FromRoute] RemoveGoalRequest request)
        => await _mediator.Send(request);

}


