using System.Collections.Generic;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Builder
{
    // PATRÓN: Builder – INICIO
    /// <summary>
    /// Builder concreto para Pleurotus.
    /// </summary>
    public class ProtocoloPleurotusBuilder : IProtocoloCultivoBuilder
    {
        private readonly List<FaseProtocolo> _fases = new List<FaseProtocolo>();

        public IProtocoloCultivoBuilder AñadirFaseInoculacion()
        {
            _fases.Add(new FaseProtocolo("Inoculación", 90, 10, 7));
            return this;
        }

        public IProtocoloCultivoBuilder AñadirFaseColonizacion()
        {
            _fases.Add(new FaseProtocolo("Colonización", 85, 20, 14));
            return this;
        }

        public IProtocoloCultivoBuilder AñadirFaseFructificacion()
        {
            _fases.Add(new FaseProtocolo("Fructificación", 80, 50, 10));
            return this;
        }

        public ProtocoloCultivo Construir()
        {
            return new ProtocoloCultivo(_fases.AsReadOnly());
        }
    }
    // PATRÓN: Builder – FIN
}
