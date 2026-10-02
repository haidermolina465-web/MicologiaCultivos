using System.Collections.Generic;
using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Decorator
{
    // PATRÓN: Decorator – INICIO
    public class ControlContaminacionDecorator : ProtocoloDecorator
    {
        public ControlContaminacionDecorator(IProtocoloCultivo componente) : base(componente)
        {
        }

        public override IReadOnlyList<FaseProtocolo> Fases => _componente.Fases;

        public override string Descripcion()
        {
            return $"{_componente.Descripcion()} + Control de contaminación";
        }
    }
    // PATRÓN: Decorator – FIN
}
