using Microsoft.EntityFrameworkCore;
using JAXPORT.Models;

namespace JAXPORT.Services
{
    public class PortService : IPortService
    {
        private readonly JaxportDbContext _db;

        public PortService(JaxportDbContext db)
        {
            _db = db;
        }
    }
}
