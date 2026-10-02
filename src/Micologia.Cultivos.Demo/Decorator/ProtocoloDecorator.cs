using System;
using System.Collections.Generic;
using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Decorator
{
    // PATRÓN: Decorator – INICIO
    public abstract class ProtocoloDecorator : IProtocoloCultivo
    {
        protected readonly IProtocoloCultivo _componente;

        protected ProtocoloDecorator(IProtocoloCultivo componente)
        {
            _componente = componente ?? throw new ArgumentNullException(nameof(componente));
        }

        public virtual IReadOnlyList<FaseProtocolo> Fases => _componente.Fases;

        public virtual string Descripcion()
        {
            return _componente.Descripcion();
        }
    }
    // PATRÓN: Decorator – FIN
}
