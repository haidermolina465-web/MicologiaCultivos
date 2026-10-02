using Micologia.Cultivos.Demo.Common;

namespace Micologia.Cultivos.Demo.Composite
{
    // PATRÓN: Composite – INICIO
    public class Bandeja : IElementoCultivo
    {
        private readonly string _identificador;
        private string _estado = "Sin aplicar protocolo";

        public Bandeja(string identificador)
        {
            _identificador = identificador ?? string.Empty;
        }

        public void AplicarProtocolo(IProtocoloCultivo protocolo)
        {
            if (protocolo == null)
                return;

            _estado = $"Protocolo aplicado a bandeja {_identificador} ({protocolo.Fases.Count} fases)";
        }

        public string ObtenerEstadoSeguimiento()
        {
            return _estado;
        }
    }
    // PATRÓN: Composite – FIN
}
