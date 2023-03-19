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
public class DailyMeasurementController
{
    private readonly IMediator _mediator;

    public DailyMeasurementController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet("today", Name = "GetDailyMeasurementTodayRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDailyMeasurementByDateResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDailyMeasurementByDateResponse>> GetToday()
    {
        return await _mediator.Send(new GetDailyMeasurementByDateRequest());
    }

    [HttpGet("date/{date}", Name = "GetDailyMeasurementByDateRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDailyMeasurementByDateResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDailyMeasurementByDateResponse>> GetByDate([FromRoute] GetDailyMeasurementByDateRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpGet("{dailyMeasurementId}", Name = "GetDailyMeasurementByIdRoute")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDailyMeasurementByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDailyMeasurementByIdResponse>> GetById([FromRoute] GetDailyMeasurementByIdRequest request)
    {
        var response = await _mediator.Send(request);

        if (response.DailyMeasurement == null)
        {
            return new NotFoundObjectResult(request.DailyMeasurementId);
        }

        return response;
    }

    [HttpGet(Name = "GetDailyMeasurementsRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDailyMeasurementsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDailyMeasurementsResponse>> Get()
        => await _mediator.Send(new GetDailyMeasurementsRequest());

    [HttpPost(Name = "CreateDailyMeasurementRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateDailyMeasurementResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateDailyMeasurementResponse>> Create([FromBody] CreateDailyMeasurementRequest request)
        => await _mediator.Send(request);

    [HttpGet("page/{pageSize}/{index}", Name = "GetDailyMeasurementsPageRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDailyMeasurementsPageResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDailyMeasurementsPageResponse>> Page([FromRoute] GetDailyMeasurementsPageRequest request)
        => await _mediator.Send(request);

    [HttpPut(Name = "UpdateDailyMeasurementRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateDailyMeasurementResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateDailyMeasurementResponse>> Update([FromBody] UpdateDailyMeasurementRequest request)
        => await _mediator.Send(request);

    [HttpDelete("{dailyMeasurementId}", Name = "RemoveDailyMeasurementRoute")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(RemoveDailyMeasurementResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<RemoveDailyMeasurementResponse>> Remove([FromRoute] RemoveDailyMeasurementRequest request)
        => await _mediator.Send(request);

}


