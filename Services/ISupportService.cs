using HealthDataCollector.Models;
using JAXPORT.Models;

namespace JAXPORT.Services
{
    public interface ISupportService
    {
        Task<ServiceResult<DbHealthDto>> GetDbHealthStatusAsync();
    }
}
