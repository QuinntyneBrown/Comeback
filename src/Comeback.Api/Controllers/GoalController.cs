using System.Net;
using System.Threading.Tasks;
using Comeback.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Comeback.Api.Controllers
{
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
        [ProducesResponseType(typeof(GetGoalById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetGoalById.Response>> GetById([FromRoute]GetGoalById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Goal == null)
            {
                return new NotFoundObjectResult(request.GoalId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetGoalsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetGoals.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetGoals.Response>> Get()
            => await _mediator.Send(new GetGoals.Request());
        
        [HttpPost(Name = "CreateGoalRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateGoal.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateGoal.Response>> Create([FromBody]CreateGoal.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetGoalsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetGoalsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetGoalsPage.Response>> Page([FromRoute]GetGoalsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateGoalRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateGoal.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateGoal.Response>> Update([FromBody]UpdateGoal.Request request)
            => await _mediator.Send(request);

        [HttpPut("acheive", Name = "AchieveGoalRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AchieveGoal.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AchieveGoal.Response>> Achieve([FromBody] AchieveGoal.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{goalId}", Name = "RemoveGoalRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveGoal.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveGoal.Response>> Remove([FromRoute]RemoveGoal.Request request)
            => await _mediator.Send(request);
        
    }
}
