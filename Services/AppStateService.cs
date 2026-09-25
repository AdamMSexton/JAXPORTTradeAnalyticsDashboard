using JAXPORT.Data;

namespace JAXPORT.Services
{
    public class AppStateService 
    {
        public IReadOnlyList<JaxportReferencePorts> Ports { get; private set; }
            = [];

        public void SetPorts(List<JaxportReferencePorts> ports)
        {
            Ports = ports;
        }

    }
}
