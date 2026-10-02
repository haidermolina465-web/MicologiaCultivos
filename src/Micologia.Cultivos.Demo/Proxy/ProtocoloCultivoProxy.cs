using System;
using System.Collections.Generic;
using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Model;

namespace Micologia.Cultivos.Demo.Proxy
{
    // PATRÓN: Cache Proxy – INICIO
    public class ProtocoloCultivoProxy : IProtocoloCultivo
    {
        private readonly Dictionary<string, IProtocoloCultivo> _cache = new Dictionary<string, IProtocoloCultivo>(StringComparer.OrdinalIgnoreCase);
        private readonly IProtocoloCultivoFactory _factory;
        private IProtocoloCultivo? _actual;
        private string _especie = string.Empty;

        public ProtocoloCultivoProxy(IProtocoloCultivoFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IReadOnlyList<FaseProtocolo> Fases
        {
            get
            {
                if (_actual == null)
                    return new List<FaseProtocolo>().AsReadOnly();
                return _actual.Fases;
            }
        }

        public IProtocoloCultivo ObtenerProtocolo(string especie)
        {
            if (string.IsNullOrWhiteSpace(especie))
                throw new ArgumentException("La especie no puede estar vacía.", nameof(especie));

            string clave = especie.Trim();

            if (_cache.TryGetValue(clave, out IProtocoloCultivo? cacheado))
            {
                _actual = cacheado;
                _especie = clave;
                return cacheado;
            }

            var nuevo = _factory.CrearProtocolo(clave);
            _cache[clave] = nuevo;
            _actual = nuevo;
            _especie = clave;
            return nuevo;
        }

        public string Descripcion()
        {
            if (_actual == null)
                return "Proxy sin protocolo cargado";
            return $"Proxy[{_especie}] -> {_actual.Descripcion()}";
        }
    }
    // PATRÓN: Cache Proxy – FIN
}
