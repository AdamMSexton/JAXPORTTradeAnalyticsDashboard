using HealthDataCollector.Models;
using JAXPORT.Models;
using Npgsql;

namespace JAXPORT.Services
{
    public class SupportService : ISupportService
    {
        private readonly JaxportDbContext _db;
        private readonly IConfiguration _config;

        public SupportService(JaxportDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<ServiceResult<DbHealthDto>> GetDbHealthStatusAsync()
        {
            var connectionString = _config.GetConnectionString("JaxportDatabase");
            var cs = new NpgsqlConnectionStringBuilder(connectionString);
            bool connected = false;

            try
            {
                connected = await _db.Database.CanConnectAsync();

                return ServiceResult<DbHealthDto>.Ok(new DbHealthDto
                {
                    host = cs.Host ?? "Unknown",
                    connected = connected
                });
            }
            catch
            {
                return ServiceResult<DbHealthDto>.Ok(new DbHealthDto
                {
                    host = cs.Host ?? "Unknown",
                    connected = false
                });
            }
        }
    }
}
