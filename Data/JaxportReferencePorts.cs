using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAXPORT.Data
{
    [Table("ports", Schema = "reference")]
    public class JaxportReferencePorts
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("port_name")]
        public string PortName { get; set; } = string.Empty;

        [Column("country")]
        public string Country { get; set; } = string.Empty;

        [Column("state")]
        public string? State { get; set; }

        [Column("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }
    }
}
