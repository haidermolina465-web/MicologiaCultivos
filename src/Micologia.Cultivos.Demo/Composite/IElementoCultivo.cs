using Micologia.Cultivos.Demo.Common;

namespace Micologia.Cultivos.Demo.Composite
{
    // PATRÓN: Composite – INICIO
    public interface IElementoCultivo
    {
        void AplicarProtocolo(IProtocoloCultivo protocolo);
        string ObtenerEstadoSeguimiento();
    }
    // PATRÓN: Composite – FIN
}
