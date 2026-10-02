using System.Collections.Generic;
using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Decorator
{
    // PATRÓN: Decorator – INICIO
    public class RetrasoFaseDecorator : ProtocoloDecorator
    {
        private readonly int _diasRetraso;

        public RetrasoFaseDecorator(IProtocoloCultivo componente, int diasRetraso) : base(componente)
        {
            _diasRetraso = diasRetraso;
        }

        public override IReadOnlyList<FaseProtocolo> Fases => _componente.Fases;

        public override string Descripcion()
        {
            return $"{_componente.Descripcion()} + Retraso de fase ({_diasRetraso} días)";
        }
    }
    // PATRÓN: Decorator – FIN
}
