using HealthDataCollector.Models;
using JAXPORT.Models;

namespace JAXPORT.Services
{
    public interface IPortService
    {
        Task<ServiceResult<List<PortListItemDto>>> GetPortsByDateAsync(PortByDateDto request);
    }
}
