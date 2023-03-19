// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;


using Microsoft.EntityFrameworkCore;


namespace Comeback.Core.AggregateModel.GoalAggregate.Queries;

public class GetGoalsRequest : IRequest<GetGoalsResponse> { }

public class GetGoalsResponse : ResponseBase
{
    public List<GoalDto> Goals { get; set; }
}

public class GetGoalsHandler : IRequestHandler<GetGoalsRequest, GetGoalsResponse>
{
    private readonly IComebackDbContext _context;

    public GetGoalsHandler(IComebackDbContext context)
        => _context = context;

    public async Task<GetGoalsResponse> Handle(GetGoalsRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            Goals = await _context.Goals.Select(x => x.ToDto()).ToListAsync()
        };
    }

}


