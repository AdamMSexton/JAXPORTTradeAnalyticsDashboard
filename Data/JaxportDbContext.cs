using JAXPORT.Data;
using Microsoft.EntityFrameworkCore;

namespace JAXPORT.Models;
public class JaxportDbContext : DbContext
{
    public JaxportDbContext(DbContextOptions<JaxportDbContext> options)
        : base(options)
    {
    }
    public DbSet<JaxportCleanPiers> Piers => Set<JaxportCleanPiers>();
    public DbSet<JaxportReferencePorts> Ports => Set<JaxportReferencePorts>();
}