using System;
using Micologia.Cultivos.Demo.Builder;
using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Decorator;

namespace Micologia.Cultivos.Demo.Proxy
{
    // PATRÓN: Cache Proxy – INICIO
    public class ProtocoloCultivoRealFactory : IProtocoloCultivoFactory
    {
        private readonly ProtocoloCultivoDirector _director = new ProtocoloCultivoDirector();

        public IProtocoloCultivo CrearProtocolo(string especie)
        {
            if (string.IsNullOrWhiteSpace(especie))
                throw new ArgumentException("La especie no puede estar vacía.", nameof(especie));

            IProtocoloCultivoBuilder builder;
            string especieLower = especie.Trim().ToLowerInvariant();

            switch (especieLower)
            {
                case "pleurotus":
                    builder = new ProtocoloPleurotusBuilder();
                    break;
                case "agaricus":
                    builder = new ProtocoloAgaricusBuilder();
                    break;
                default:
                    throw new ArgumentException($"Especie no soportada: {especie}", nameof(especie));
            }

            var proto = _director.ConstruirProtocolo(builder);
            return new ProtocoloCultivoBase(proto);
        }
    }
    // PATRÓN: Cache Proxy – FIN
}
