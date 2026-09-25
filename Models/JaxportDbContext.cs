using Microsoft.EntityFrameworkCore;

namespace JAXPORT.Models;
public class JaxportDbContext : DbContext
{
    public JaxportDbContext(DbContextOptions<JaxportDbContext> options)
        : base(options)
    {
    }
}