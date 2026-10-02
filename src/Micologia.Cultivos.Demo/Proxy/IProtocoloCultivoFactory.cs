using Micologia.Cultivos.Demo.Common;

namespace Micologia.Cultivos.Demo.Proxy
{
    // PATRÓN: Cache Proxy – INICIO
    public interface IProtocoloCultivoFactory
    {
        IProtocoloCultivo CrearProtocolo(string especie);
    }
    // PATRÓN: Cache Proxy – FIN
}
