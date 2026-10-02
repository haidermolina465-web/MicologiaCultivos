using System.Collections.Generic;
using Micologia.Cultivos.Demo.Common;

namespace Micologia.Cultivos.Demo.Composite
{
    // PATRÓN: Composite – INICIO
    public class BloqueIncubacion : IElementoCultivo
    {
        private readonly string _nombre;
        private readonly List<IElementoCultivo> _elementos = new List<IElementoCultivo>();

        public BloqueIncubacion(string nombre)
        {
            _nombre = nombre ?? string.Empty;
        }

        public void Agregar(IElementoCultivo elemento)
        {
            if (elemento != null)
                _elementos.Add(elemento);
        }

        public void AplicarProtocolo(IProtocoloCultivo protocolo)
        {
            if (protocolo == null)
                return;

            for (int i = 0; i < _elementos.Count; i++)
            {
                _elementos[i].AplicarProtocolo(protocolo);
            }
        }

        public string ObtenerEstadoSeguimiento()
        {
            if (_elementos.Count == 0)
                return $"Bloque {_nombre}: sin elementos";

            List<string> estados = new List<string>(_elementos.Count);
            for (int i = 0; i < _elementos.Count; i++)
            {
                estados.Add(_elementos[i].ObtenerEstadoSeguimiento());
            }

            return $"Bloque {_nombre} ({_elementos.Count} elementos) -> [{string.Join(" | ", estados)}]";
        }
    }
    // PATRÓN: Composite – FIN
}
