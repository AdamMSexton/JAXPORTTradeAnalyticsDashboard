namespace JAXPORT.Models
{
    public class DbHealthDto
    {
        public string host { get; set; } = string.Empty;
        public bool connected { get; set; } = false;
    }
}
