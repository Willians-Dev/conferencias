namespace ConferenciasApi.Models;

public class Asistente
{
    public int AsistenteId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Telefono { get; set; }

    public List<Registro> Registros { get; set; } = new();
}