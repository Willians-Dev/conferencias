namespace ConferenciasApi.Models;

public class Registro
{
    public int RegistroId { get; set; }

    public int ConferenciaId { get; set; }
    public Conferencia? Conferencia { get; set; }

    public int AsistenteId { get; set; }
    public Asistente? Asistente { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}