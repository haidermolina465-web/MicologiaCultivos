using System;
using System.Collections.Generic;
using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Decorator
{
    // PATRÓN: Decorator – INICIO
    public class ProtocoloCultivoBase : IProtocoloCultivo
    {
        private readonly ProtocoloCultivo _protocolo;

        public ProtocoloCultivoBase(ProtocoloCultivo protocolo)
        {
            _protocolo = protocolo ?? throw new ArgumentNullException(nameof(protocolo));
        }

        public IReadOnlyList<FaseProtocolo> Fases => _protocolo.Fases;

        public string Descripcion()
        {
            return $"Protocolo base ({_protocolo.Fases.Count} fases)";
        }
    }
    // PATRÓN: Decorator – FIN
}
