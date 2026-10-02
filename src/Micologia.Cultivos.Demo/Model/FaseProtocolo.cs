namespace Micologia.Cultivos.Demo.Model
{
    /// <summary>
    /// Representa una fase del protocolo de cultivo de setas.
    /// </summary>
    public record FaseProtocolo(
        string Nombre,
        int HumedadPorcentaje,
        int VentilacionPorcentaje,
        int DuracionDias
    );
}
