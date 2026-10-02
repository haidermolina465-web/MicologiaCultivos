# Micología aplicada – Seguimiento de cultivos de setas

## Problema

Un sistema para seguir cultivos de setas por bloque de incubación. Cada especie requiere un protocolo distinto de humedad, ventilación y fases (inoculación, colonización, fructificación). 

El problema es crear protocolos válidos y coherentes por especie, reutilizarlos entre siembras, poder añadir ajustes circunstanciales sin modificar el protocolo base, y tratar bloques, subbloques y bandejas de forma uniforme. Si se crearan directamente con `new`, aparecerían condicionales dispersos, duplicación de código, acoplamiento y pérdida de reutilización.

## Patrones utilizados

Se han aplicado **4 patrones de diseño** para resolver problemas reales del sistema:

| Patrón | Tipo | Dónde se aplica | Justificación |
|---|---|---|---|
| **Builder** | Creacional | `Builder/` (`IProtocoloCultivoBuilder`, `ProtocoloPleurotusBuilder`, `ProtocoloAgaricusBuilder`, `ProtocoloCultivoDirector`) | Construye los protocolos paso a paso con orden lógico (inoculación → colonización → fructificación), garantizando que estén completos, coherentes e inmutables. |
| **Composite** | Estructural | `Composite/` (`IElementoCultivo`, `Bandeja`, `BloqueIncubacion`) | Permite tratar hojas (`Bandeja`) y compuestos (`BloqueIncubacion`) de forma uniforme. El protocolo se aplica a todo el árbol jerárquico sin distinguir entre elemento individual o grupo. |
| **Decorator** | Estructural | `Decorator/` (`ProtocoloCultivoBase`, `ProtocoloDecorator`, `RetrasoFaseDecorator`, `ControlContaminacionDecorator`) | Añade ajustes circunstanciales (retraso de fase, control de contaminación) **sin modificar el protocolo base**. Esto permite reutilizar el mismo protocolo entre siembras distintas. |
| **Cache Proxy** | Estructural (Cache Proxy) | `Proxy/` (`ProtocoloCultivoProxy`, `IProtocoloCultivoFactory`, `ProtocoloCultivoRealFactory`) | Cachea los protocolos por especie. Solo los construye la primera vez que se solicitan y devuelve **la misma instancia** en solicitudes posteriores, evitando reconstrucciones innecesarias. |

## Cómo demuestra el código que los patrones funcionan

El programa de consola (`Program.cs`) demuestra el funcionamiento de cada patrón:

1. **Builder + Cache Proxy**: Solicita el protocolo de *Pleurotus* dos veces consecutivas. Se comprueba con `ReferenceEquals` que **devuelve la misma instancia** (demuestra la caché). Además se muestra que crea protocolos distintos para *Pleurotus* y *Agaricus* con parámetros coherentes por especie (Builder).

2. **Decorator**: Envuelve el protocolo base con `RetrasoFaseDecorator` y `ControlContaminacionDecorator`. Se muestra que **la descripción del protocolo decorado cambia**, mientras que **el protocolo base permanece sin modificar**. Esto demuestra que los ajustes no alteran el componente original (reutilizable entre siembras).

3. **Composite**: Se crea una estructura jerárquica (`Bloque Incubación A` → contiene subbloques → contienen bandejas). Se aplica el protocolo decorado **al árbol completo** y se muestra el estado agregado. Esto demuestra que **trata hojas y compuestos de forma uniforme**, sin distinguir entre ellos.

La salida por consola muestra claramente cada paso, lo que permite verificar que los 4 patrones funcionan correctamente.

## Estructura del proyecto

```text
MicologiaCultivos/
├── Micologia.Cultivos.sln
├── README.md
├── DEFENSA.md
├── openspec/
│   └── specs/
│       └── micologia-cultivos/
│           └── spec.md
└── src/
    ├── Micologia.Cultivos.Demo/
    │   ├── Program.cs
    │   ├── Micologia.Cultivos.Demo.csproj
    │   ├── Common/
    │   ├── Model/
    │   ├── Builder/
    │   ├── Composite/
    │   ├── Decorator/
    │   └── Proxy/
    └── Micologia.Cultivos.Tests/
        ├── MicologiaCultivosTests.cs
        └── Micologia.Cultivos.Tests.csproj
