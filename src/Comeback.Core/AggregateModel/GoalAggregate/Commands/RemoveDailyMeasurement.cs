// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;





namespace Comeback.Core.AggregateModel.GoalAggregate.Commands;

 public class RemoveDailyMeasurementRequest : IRequest<RemoveDailyMeasurementResponse>
 {
     public Guid DailyMeasurementId { get; set; }
 }

 public class RemoveDailyMeasurementResponse : ResponseBase
 {
     public DailyMeasurementDto DailyMeasurement { get; set; }
 }

 public class RemoveDailyMeasurementHandler : IRequestHandler<RemoveDailyMeasurementRequest, RemoveDailyMeasurementResponse>
 {
     private readonly IComebackDbContext _context;

     public RemoveDailyMeasurementHandler(IComebackDbContext context)
         => _context = context;

     public async Task<RemoveDailyMeasurementResponse> Handle(RemoveDailyMeasurementRequest request, CancellationToken cancellationToken)
     {
         var dailyMeasurement = await _context.DailyMeasurements.SingleAsync(x => x.DailyMeasurementId == request.DailyMeasurementId);

         _context.DailyMeasurements.Remove(dailyMeasurement);

         await _context.SaveChangesAsync(cancellationToken);

         return new RemoveDailyMeasurementResponse()
         {
             DailyMeasurement = dailyMeasurement.ToDto()
         };
     }

 }


