using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Comeback.Api.Core;
using Comeback.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Comeback.Api.Features
{
    public class UpdateDailyMeasurement
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DailyMeasurement).NotNull();
                RuleFor(request => request.DailyMeasurement).SetValidator(new DailyMeasurementValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public DailyMeasurementDto DailyMeasurement { get; set; }
        }

        public class Response : ResponseBase
        {
            public DailyMeasurementDto DailyMeasurement { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IComebackDbContext _context;

            public Handler(IComebackDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var dailyMeasurement = await _context.DailyMeasurements.SingleAsync(x => x.DailyMeasurementId == request.DailyMeasurement.DailyMeasurementId);

                dailyMeasurement.Update(request.DailyMeasurement.Description);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    DailyMeasurement = dailyMeasurement.ToDto()
                };
            }

        }
    }
}
