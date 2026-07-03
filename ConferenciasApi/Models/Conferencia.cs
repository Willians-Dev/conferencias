namespace ConferenciasApi.Models;

public class Conferencia
{
    public int ConferenciaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Ubicacion { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public List<Registro>? Registros { get; set; }
}