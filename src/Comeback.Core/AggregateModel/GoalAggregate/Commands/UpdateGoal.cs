// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;


namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

public class UpdateGoalValidator : AbstractValidator<UpdateGoalRequest>
 {
     public UpdateGoalValidator()
     {
         RuleFor(request => request.Goal).NotNull();
         RuleFor(request => request.Goal).SetValidator(new GoalValidator());
     }

 }

 public class UpdateGoalRequest : IRequest<UpdateGoalResponse>
 {
     public GoalDto Goal { get; set; }
 }

 public class UpdateGoalResponse : ResponseBase
 {
     public GoalDto Goal { get; set; }
 }

 public class UpdateGoalHandler : IRequestHandler<UpdateGoalRequest, UpdateGoalResponse>
 {
     private readonly IComebackDbContext _context;

     public UpdateGoalHandler(IComebackDbContext context)
         => _context = context;

     public async Task<UpdateGoalResponse> Handle(UpdateGoalRequest request, CancellationToken cancellationToken)
     {
         var goal = await _context.Goals.SingleAsync(x => x.GoalId == request.Goal.GoalId);

         goal.SetDescription(request.Goal.Description);

         await _context.SaveChangesAsync(cancellationToken);

         return new()
         {
             Goal = goal.ToDto()
         };
     }

 }


