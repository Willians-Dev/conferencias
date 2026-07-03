using ConferenciasApi.Data;
using ConferenciasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenciasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsistentesController : ControllerBase
{
    private readonly AppDbContext _context;

    public AsistentesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asistente>>> GetAsistentes()
    {
        return await _context.Asistentes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Asistente>> GetAsistente(int id)
    {
        var asistente = await _context.Asistentes.FindAsync(id);

        if (asistente == null)
            return NotFound();

        return asistente;
    }

    [HttpPost]
    public async Task<ActionResult<Asistente>> PostAsistente(Asistente asistente)
    {
        _context.Asistentes.Add(asistente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAsistente), new { id = asistente.AsistenteId }, asistente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsistente(int id, Asistente asistente)
    {
        if (id != asistente.AsistenteId)
            return BadRequest();

        _context.Entry(asistente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsistente(int id)
    {
        var asistente = await _context.Asistentes.FindAsync(id);

        if (asistente == null)
            return NotFound();

        _context.Asistentes.Remove(asistente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}