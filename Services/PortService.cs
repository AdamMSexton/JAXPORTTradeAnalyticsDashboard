using Microsoft.EntityFrameworkCore;
using JAXPORT.Models;
using HealthDataCollector.Models;

namespace JAXPORT.Services
{
    public class PortService : IPortService
    {
        private readonly JaxportDbContext _db;

        public PortService(JaxportDbContext db)
        {
            _db = db;
        }

        public async Task<ServiceResult<List<PortListItemDto>>> GetPortsByDateAsync(PortByDateDto request)
        {
            // If dates are out of order, swap them
            if (request.EndDate < request.StartDate)
            {
                DateOnly temp = request.EndDate;
                request.StartDate = request.EndDate;
                request.EndDate = temp;
            }

            // Piers DB stores year and month seperatly.
            // Create composite a date, i.e. month number, to prevent cross year issues
            int startPoint = (request.StartDate.Year * 12) + request.StartDate.Month;
            int endPoint = (request.EndDate.Year * 12) + request.EndDate.Month;



            // Start with date range
            var piersInRange = _db.Piers
                .Where(x => ((x.Year * 12) + x.Month) >= startPoint 
                && ((x.Year * 12) + x.Month) <= endPoint);

            // Get list of all distinct US Ports and States using above date range
            var usPorts = await piersInRange
                .Select (p => new {p.UsPort, p.UsPortState})
                .Distinct()
                .OrderBy(x => x.UsPortState)
                .ThenBy(x => x.UsPort)
                .ToListAsync();
            
            // Get list of all distinct Foreign Ports and Countries using above date range
            var foreignPorts = await piersInRange
                .Select(p => new { p.ForeignInitialPort, p.ForeignInitialCountry })
                .Distinct()
                .OrderBy(x => x.ForeignInitialCountry)
                .ThenBy(x => x.ForeignInitialPort)
                .ToListAsync();

            // Take the list of US Ports and find equal entries in reference.ports
            var matchedUsPorts = await _db.Ports
                .Where(r => usPorts.Any(p => p.UsPort == r.PortName && p.UsPortState == r.State))
                .Select(r => new PortListItemDto
                {
                    Id = r.Id,
                    DisplayName = r.DisplayName
                })
                .ToListAsync();

            // Take the list of Foreign Ports and find equal entries in reference.ports
            var matchedForeignPorts = await _db.Ports
                .Where(r => foreignPorts.Any(p => p.ForeignInitialPort == r.PortName && p.ForeignInitialCountry == r.Country))
                .Select(r => new PortListItemDto
                {
                    Id = r.Id,
                    DisplayName = r.DisplayName
                })
                .ToListAsync();

            var completedPortList = matchedUsPorts;
            completedPortList.AddRange(matchedForeignPorts);

            return ServiceResult<List<PortListItemDto>>.Ok(completedPortList);
        }
    }
}
