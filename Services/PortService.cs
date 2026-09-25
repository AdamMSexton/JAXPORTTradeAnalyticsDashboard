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

            List<PortListItemDto> ports = await _db.clean
                .Where( XmlConfigurationExtensions=> )
        }
    }
}
