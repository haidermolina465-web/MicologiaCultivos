Set-Location "C:\Temp\MicologiaCultivos"

# Borrar README si está vacío o existe
if (Test-Path "README.md") {
    Remove-Item "README.md" -Force
}

# Escribir el README completo (método .NET, muy fiable)
$texto = @"
# Micología aplicada – Seguimiento de cultivos de setas

## Problema

Sistema para seguir cultivos de setas por bloque de incubación. Cada especie requiere un protocolo distinto de humedad, ventilación y fases (inoculación, colonización, fructificación). El micólogo responsable de las siembras necesita crear protocolos de cultivo válidos y coherentes por especie para cada nueva siembra.

## Patrones usados

| Patrón | Tipo | Explicación |
|---|---|---|
| **Builder** | Creacional | Construcción ordenada, completa y coherente de protocolos por especie (inoculación → colonización → fructificación). Garantiza completitud e inmutabilidad. |
| **Composite** | Estructural | Tratamiento uniforme de bloques, subbloques, bandejas y sustratos a través de `IElementoCultivo`. Permite recorrer el árbol jerárquico sin distinguir entre hoja y compuesto. |
| **Decorator** | Estructural | Añade ajustes circunstanciales (retraso de fase, control de contaminación) sobre el protocolo existente **sin modificar el protocolo base**, preservando su inmutabilidad y permitiendo apilado. |
| **Cache Proxy** | Estructural (Cache Proxy) | Reutiliza protocolos por especie entre siembras. Cachea por especie y devuelve la misma instancia, construyendo únicamente la primera vez. Desacopla al cliente de la lógica de creación. |

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
