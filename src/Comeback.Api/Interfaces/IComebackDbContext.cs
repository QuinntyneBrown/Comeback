using Comeback.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Comeback.Api.Interfaces
{
    public interface IComebackDbContext
    {
        DbSet<DailyMeasurement> DailyMeasurements { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
