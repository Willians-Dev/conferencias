using ConferenciasApi.Data;
using ConferenciasApi.DTOs;
using ConferenciasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenciasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrosController : ControllerBase
{
    private readonly AppDbContext _context;

    public RegistrosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetRegistros()
    {
        var registros = await _context.Registros
            .Include(r => r.Conferencia)
            .Include(r => r.Asistente)
            .Select(r => new
            {
                r.RegistroId,
                r.FechaRegistro,
                Conferencia = new
                {
                    r.ConferenciaId,
                    r.Conferencia!.Nombre,
                    r.Conferencia.Fecha,
                    r.Conferencia.Ubicacion
                },
                Asistente = new
                {
                    r.AsistenteId,
                    r.Asistente!.Nombre,
                    r.Asistente.Apellido,
                    r.Asistente.Email
                }
            })
            .ToListAsync();

        return Ok(registros);
    }

    [HttpPost]
    public async Task<IActionResult> PostRegistro(CrearRegistroDto dto)
    {
        var conferenciaExiste = await _context.Conferencias
            .AnyAsync(c => c.ConferenciaId == dto.ConferenciaId);

        if (!conferenciaExiste)
            return BadRequest("La conferencia no existe.");

        var asistenteExiste = await _context.Asistentes
            .AnyAsync(a => a.AsistenteId == dto.AsistenteId);

        if (!asistenteExiste)
            return BadRequest("El asistente no existe.");

        var yaRegistrado = await _context.Registros
            .AnyAsync(r => r.ConferenciaId == dto.ConferenciaId &&
                           r.AsistenteId == dto.AsistenteId);

        if (yaRegistrado)
            return BadRequest("El asistente ya está registrado en esta conferencia.");

        var registro = new Registro
        {
            ConferenciaId = dto.ConferenciaId,
            AsistenteId = dto.AsistenteId,
            FechaRegistro = DateTime.UtcNow
        };

        _context.Registros.Add(registro);
        await _context.SaveChangesAsync();

        return Created("", new
        {
            registro.RegistroId,
            registro.ConferenciaId,
            registro.AsistenteId,
            registro.FechaRegistro
        });
    }
}