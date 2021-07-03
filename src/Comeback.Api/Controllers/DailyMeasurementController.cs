using System.Net;
using System.Threading.Tasks;
using Comeback.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Comeback.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyMeasurementController
    {
        private readonly IMediator _mediator;

        public DailyMeasurementController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{dailyMeasurementId}", Name = "GetDailyMeasurementByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDailyMeasurementById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDailyMeasurementById.Response>> GetById([FromRoute] GetDailyMeasurementById.Request request)
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
        [ProducesResponseType(typeof(GetDailyMeasurements.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDailyMeasurements.Response>> Get()
            => await _mediator.Send(new GetDailyMeasurements.Request());

        [HttpPost(Name = "CreateDailyMeasurementRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateDailyMeasurement.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateDailyMeasurement.Response>> Create([FromBody] CreateDailyMeasurement.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetDailyMeasurementsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDailyMeasurementsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDailyMeasurementsPage.Response>> Page([FromRoute] GetDailyMeasurementsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateDailyMeasurementRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateDailyMeasurement.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateDailyMeasurement.Response>> Update([FromBody] UpdateDailyMeasurement.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{dailyMeasurementId}", Name = "RemoveDailyMeasurementRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDailyMeasurement.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDailyMeasurement.Response>> Remove([FromRoute] RemoveDailyMeasurement.Request request)
            => await _mediator.Send(request);

    }
}
