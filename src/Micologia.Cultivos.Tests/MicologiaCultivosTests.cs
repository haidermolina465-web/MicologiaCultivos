using Micologia.Cultivos.Demo.Builder;
using Micologia.Cultivos.Demo.Common;
using Micologia.Cultivos.Demo.Composite;
using Micologia.Cultivos.Demo.Decorator;
using Micologia.Cultivos.Demo.Proxy;
using Xunit;

namespace Micologia.Cultivos.Tests
{
    public class MicologiaCultivosTests
    {
        [Fact]
        public void CA01_ProtocoloPleurotus_TresFasesEnOrden()
        {
            var director = new ProtocoloCultivoDirector();
            var proto = director.ConstruirProtocolo(new ProtocoloPleurotusBuilder());
            Assert.Equal(3, proto.Fases.Count);
            Assert.Equal("Inoculación", proto.Fases[0].Nombre);
            Assert.Equal("Colonización", proto.Fases[1].Nombre);
            Assert.Equal("Fructificación", proto.Fases[2].Nombre);
        }

        [Fact]
        public void CA02_ProtocolosDifierenEntreEspecies()
        {
            var d = new ProtocoloCultivoDirector();
            var p = d.ConstruirProtocolo(new ProtocoloPleurotusBuilder());
            var a = d.ConstruirProtocolo(new ProtocoloAgaricusBuilder());
            Assert.NotEqual(p.Fases[0].HumedadPorcentaje, a.Fases[0].HumedadPorcentaje);
        }

        [Fact]
        public void CA03_CompositeTrataUniforme()
        {
            var px = new ProtocoloCultivoProxy(new ProtocoloCultivoRealFactory());
            var pr = px.ObtenerProtocolo("Pleurotus");
            var raiz = new BloqueIncubacion("Raiz");
            var sub = new BloqueIncubacion("Sub");
            sub.Agregar(new Bandeja("B1"));
            sub.Agregar(new Bandeja("B2"));
            raiz.Agregar(sub);
            raiz.AplicarProtocolo(pr);
            Assert.Contains("Raiz", raiz.ObtenerEstadoSeguimiento());
        }

        [Fact]
        public void CA04_DecoradorNoModificaBase()
        {
            var px = new ProtocoloCultivoProxy(new ProtocoloCultivoRealFactory());
            var b = px.ObtenerProtocolo("Pleurotus");
            var db = b.Descripcion();
            IProtocoloCultivo dec = b;
            dec = new RetrasoFaseDecorator(dec, 5);
            dec = new ControlContaminacionDecorator(dec);
            Assert.Equal(db, b.Descripcion());
            Assert.NotEqual(db, dec.Descripcion());
        }

        [Fact]
        public void CA05_CacheProxyReutilizaInstancia()
        {
            var px = new ProtocoloCultivoProxy(new ProtocoloCultivoRealFactory());
            var x1 = px.ObtenerProtocolo("Pleurotus");
            var x2 = px.ObtenerProtocolo("Pleurotus");
            Assert.Same(x1, x2);
        }

        [Fact]
        public void CA06_ProtocoloBaseInmutable()
        {
            var d = new ProtocoloCultivoDirector();
            var bp = new ProtocoloCultivoBase(d.ConstruirProtocolo(new ProtocoloPleurotusBuilder()));
            Assert.Equal(3, bp.Fases.Count);
        }

        [Fact]
        public void CA07_ClienteTrabajaConIProtocolo()
        {
            var px = new ProtocoloCultivoProxy(new ProtocoloCultivoRealFactory());
            IProtocoloCultivo p = px.ObtenerProtocolo("Agaricus");
            Assert.Equal(3, p.Fases.Count);
        }
    }
}
