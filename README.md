# Micología aplicada – Seguimiento de cultivos de setas

## Problema

Un sistema para seguir cultivos de setas por bloque de incubación. Cada especie requiere un protocolo distinto de humedad, ventilación y fases (inoculación, colonización, fructificación). 

El problema es crear protocolos válidos y coherentes por especie, reutilizarlos entre siembras, poder añadir ajustes circunstanciales sin modificar el protocolo base, y tratar bloques, subbloques y bandejas de forma uniforme. Si se crearan directamente con `new`, aparecerían condicionales dispersos, duplicación de código, acoplamiento y pérdida de reutilización.

## Patrones utilizados

Se han aplicado **4 patrones de diseño** para resolver problemas reales del sistema:

| Patrón | Tipo | Dónde se aplica | Justificación |
|---|---|---|---|
| **Builder** | Creacional | `Builder/` | Construye los protocolos paso a paso con orden lógico (inoculación → colonización → fructificación), garantizando que estén completos, coherentes e inmutables. |
| **Composite** | Estructural | `Composite/` | Permite tratar hojas (`Bandeja`) y compuestos (`BloqueIncubacion`) de forma uniforme. El protocolo se aplica a todo el árbol jerárquico sin distinguir entre elemento individual o grupo. |
| **Decorator** | Estructural | `Decorator/` | Añade ajustes circunstanciales (retraso de fase, control de contaminación) **sin modificar el protocolo base**, preservando su inmutabilidad y permitiendo apilado. |
| **Cache Proxy** | Estructural (Cache Proxy) | `Proxy/` | Cachea los protocolos por especie. Solo los construye la primera vez que se solicitan y devuelve **la misma instancia** en solicitudes posteriores, evitando reconstrucciones innecesarias. |

## Cómo demuestra el código que los patrones funcionan

El programa de consola (`Program.cs`) demuestra el funcionamiento de cada patrón:

1. **Builder + Cache Proxy**: Solicita el protocolo de *Pleurotus* dos veces consecutivas. Se comprueba con `ReferenceEquals` que **devuelve la misma instancia** (demuestra la caché). Además se muestra que crea protocolos distintos para *Pleurotus* y *Agaricus* con parámetros coherentes por especie.

2. **Decorator**: Envuelve el protocolo base con `RetrasoFaseDecorator` y `ControlContaminacionDecorator`. Se muestra que **la descripción del protocolo decorado cambia**, mientras que **el protocolo base permanece sin modificar**. Esto demuestra que los ajustes no alteran el componente original.

3. **Composite**: Se crea una estructura jerárquica (`Bloque Incubación A` → subbloques → bandejas). Se aplica el protocolo decorado **al árbol completo** y se muestra el estado agregado. Esto demuestra que **trata hojas y compuestos de forma uniforme**.

## Requisitos previos

- Tener instalado [.NET 8.0 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0) o superior.

## Instrucciones para ejecutar el ejemplo (paso a paso)

### Paso 1. Clonar el repositorio

```bash
git clone https://github.com/haidermolina465-web/MicologiaCultivos.git
```
Paso 2. Entrar en la carpeta del proyecto
``` bash
cd MicologiaCultivos
```
Paso 3. Compilar la solución
```
dotnet build Micologia.Cultivos.sln
```
Si todo es correcto, aparecerá: Build succeeded.

Paso 4. Ejecutar la demostración
```bash
dotnet run --project src/Micologia.Cultivos.Demo
```
Al ejecutarlo se mostrará por consola, paso a paso, cómo funcionan los 4 patrones de diseño.

Paso 5. Ejecutar las pruebas
```bash
dotnet test Micologia.Cultivos.sln
```
Deben aparecer 7 pruebas superadas: Passed: 7, Failed: 0.
```
Estructura del proyecto
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
        
