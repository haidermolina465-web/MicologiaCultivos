using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Builder
{
    // PATRÓN: Builder – INICIO
    /// <summary>
    /// Interfaz Builder para construcción paso a paso de protocolos.
    /// </summary>
    public interface IProtocoloCultivoBuilder
    {
        IProtocoloCultivoBuilder AñadirFaseInoculacion();
        IProtocoloCultivoBuilder AñadirFaseColonizacion();
        IProtocoloCultivoBuilder AñadirFaseFructificacion();
        ProtocoloCultivo Construir();
    }
    // PATRÓN: Builder – FIN
}
