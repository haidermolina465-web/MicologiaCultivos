using System.Collections.Generic;

namespace Micologia.Cultivos.Demo.Model
{
    /// <summary>
    /// Resultado inmutable del protocolo de cultivo.
    /// </summary>
    public class ProtocoloCultivo
    {
        private readonly IReadOnlyList<FaseProtocolo> _fases;

        public ProtocoloCultivo(IReadOnlyList<FaseProtocolo> fases)
        {
            _fases = fases ?? new List<FaseProtocolo>().AsReadOnly();
        }

        public IReadOnlyList<FaseProtocolo> Fases => _fases;
    }
}
