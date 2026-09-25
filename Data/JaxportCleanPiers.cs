using System.ComponentModel.DataAnnotations.Schema;


namespace JAXPORT.Data
{
    [Table("piers", Schema = "clean")]
    public class JaxportCleanPiers
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("direction")]
        public string? Direction { get; set; }

        [Column("year")]
        public short? Year { get; set; }

        [Column("quarter")]
        public string? Quarter { get; set; }

        [Column("month")]
        public short? Month { get; set; }

        [Column("us_port")]
        public string? UsPort { get; set; }

        [Column("us_port_state")]
        public string? UsPortState { get; set; }

        [Column("foreign_initial_port")]
        public string? ForeignInitialPort { get; set; }

        [Column("foreign_initial_country")]
        public string? ForeignInitialCountry { get; set; }

        [Column("foreign_initial_region")]
        public string? ForeignInitialRegion { get; set; }

        [Column("hs2")]
        public string? Hs2 { get; set; }

        [Column("hs2_description")]
        public string? Hs2Description { get; set; }

        [Column("hs4")]
        public string? Hs4 { get; set; }

        [Column("hs4_description")]
        public string? Hs4Description { get; set; }

        [Column("hs6")]
        public string? Hs6 { get; set; }

        [Column("hs6_description")]
        public string? Hs6Description { get; set; }

        [Column("is_containerized")]
        public bool? IsContainerized { get; set; }

        [Column("reefer")]
        public bool? Reefer { get; set; }

        [Column("value_usd")]
        public decimal? ValueUsd { get; set; }

        [Column("metric_tons")]
        public decimal? MetricTons { get; set; }

        [Column("teus")]
        public decimal? Teus { get; set; }
    }
}
