using ConferenciasApi.Data;
using ConferenciasApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenciasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConferenciasController : ControllerBase
{
    private readonly AppDbContext _context;

    public ConferenciasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Conferencia>>> GetConferencias()
    {
        return await _context.Conferencias.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Conferencia>> GetConferencia(int id)
    {
        var conferencia = await _context.Conferencias.FindAsync(id);

        if (conferencia == null)
            return NotFound();

        return conferencia;
    }

    [HttpPost]
    public async Task<ActionResult<Conferencia>> PostConferencia(Conferencia conferencia)
    {
        _context.Conferencias.Add(conferencia);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetConferencia), new { id = conferencia.ConferenciaId }, conferencia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConferencia(int id, Conferencia conferencia)
    {
        if (id != conferencia.ConferenciaId)
            return BadRequest();

        _context.Entry(conferencia).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConferencia(int id)
    {
        var conferencia = await _context.Conferencias.FindAsync(id);

        if (conferencia == null)
            return NotFound();

        _context.Conferencias.Remove(conferencia);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}