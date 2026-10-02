using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Common
{
    /// <summary>
    /// Contrato común para protocolo base, proxy y decoradores.
    /// </summary>
    public interface IProtocoloCultivo
    {
        /// <summary>
        /// Obtiene la lista de fases del protocolo.
        /// </summary>
        IReadOnlyList<FaseProtocolo> Fases { get; }

        /// <summary>
        /// Obtiene una descripción resumida del protocolo.
        /// </summary>
        string Descripcion();
    }
}
