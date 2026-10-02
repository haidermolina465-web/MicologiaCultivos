using System;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Builder
{
    // PATRÓN: Builder – INICIO
    /// <summary>
    /// Director que garantiza orden y completitud.
    /// </summary>
    public class ProtocoloCultivoDirector
    {
        public ProtocoloCultivo ConstruirProtocolo(IProtocoloCultivoBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder
                .AñadirFaseInoculacion()
                .AñadirFaseColonizacion()
                .AñadirFaseFructificacion()
                .Construir();
        }
    }
    // PATRÓN: Builder – FIN
}
