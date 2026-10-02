using System.Collections.Generic;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Builder
{
    // PATRÓN: Builder – INICIO
    /// <summary>
    /// Builder concreto para Agaricus.
    /// </summary>
    public class ProtocoloAgaricusBuilder : IProtocoloCultivoBuilder
    {
        private readonly List<FaseProtocolo> _fases = new List<FaseProtocolo>();

        public IProtocoloCultivoBuilder AñadirFaseInoculacion()
        {
            _fases.Add(new FaseProtocolo("Inoculación", 95, 5, 10));
            return this;
        }

        public IProtocoloCultivoBuilder AñadirFaseColonizacion()
        {
            _fases.Add(new FaseProtocolo("Colonización", 90, 15, 21));
            return this;
        }

        public IProtocoloCultivoBuilder AñadirFaseFructificacion()
        {
            _fases.Add(new FaseProtocolo("Fructificación", 85, 40, 14));
            return this;
        }

        public ProtocoloCultivo Construir()
        {
            return new ProtocoloCultivo(_fases.AsReadOnly());
        }
    }
    // PATRÓN: Builder – FIN
}
