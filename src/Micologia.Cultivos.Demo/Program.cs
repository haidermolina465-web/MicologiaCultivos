using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Composite;
using Micologia.Cultivos.Demo.Decorator;
using Micologia.Cultivos.Demo.Proxy;

namespace Micologia.Cultivos.Demo
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== MICHOLOGÍA APLICADA - SEGUIMIENTO DE CULTIVOS DE SETAS ===");
            Console.WriteLine("Demostración de: Builder, Composite, Decorator, Cache Proxy");
            Console.WriteLine();

            var factory = new ProtocoloCultivoRealFactory();
            var proxy = new ProtocoloCultivoProxy(factory);

            // 1. CACHE PROXY + BUILDER
            var p1 = proxy.ObtenerProtocolo("Pleurotus");
            Console.WriteLine("1. PATRÓN: CACHE PROXY + BUILDER");
            Console.WriteLine($"   {proxy.Descripcion()} (Fases: {p1.Fases.Count})");
            foreach (var f in p1.Fases)
            {
                Console.WriteLine($"     - {f.Nombre}: Humedad {f.HumedadPorcentaje}%, Ventilación {f.VentilacionPorcentaje}%, {f.DuracionDias} días");
            }

            var p2 = proxy.ObtenerProtocolo("Pleurotus");
            Console.WriteLine($"   ¿Misma instancia? {ReferenceEquals(p1, p2)}");

            var pa = proxy.ObtenerProtocolo("Agaricus");
            Console.WriteLine($"   Proxy[Agaricus] -> {pa.Descripcion()}");
            Console.WriteLine();

            // 2. DECORATOR
            Console.WriteLine("2. PATRÓN: DECORATOR");
            IProtocoloCultivo dec = p1;
            dec = new RetrasoFaseDecorator(dec, 3);
            dec = new ControlContaminacionDecorator(dec);
            Console.WriteLine($"   Base: {p1.Descripcion()}");
            Console.WriteLine($"   Decorado: {dec.Descripcion()}");
            Console.WriteLine();

            // 3. COMPOSITE
            Console.WriteLine("3. PATRÓN: COMPOSITE");
            var raiz = new BloqueIncubacion("Bloque Incubación A");
            var s1 = new BloqueIncubacion("Subbloque 1");
            var s2 = new BloqueIncubacion("Subbloque 2");

            s1.Agregar(new Bandeja("B-01"));
            s1.Agregar(new Bandeja("B-02"));
            s2.Agregar(new Bandeja("B-03"));
            s2.Agregar(new Bandeja("B-04"));

            raiz.Agregar(s1);
            raiz.Agregar(s2);

            Console.WriteLine($"   Inicial: {raiz.ObtenerEstadoSeguimiento()}");
            raiz.AplicarProtocolo(dec);
            Console.WriteLine($"   Tras aplicar protocolo: {raiz.ObtenerEstadoSeguimiento()}");
            Console.WriteLine();

            Console.WriteLine("=== DEMOSTRACIÓN COMPLETADA ===");
        }
    }
}
