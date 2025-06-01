using EsportsAPI.Data; 
using EsportsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[ApiController]
[Route("api/[controller]")]
[Table("equipe")]
public class EquipeController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public EquipeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var equipes = _context.Equipes
            .Include(e => e.Participantes)
            .ToList();
        return Ok(equipes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var equipe = _context.Equipes
            .Include(e => e.Participantes)
            .FirstOrDefault(e => e.Id == id);

        if (equipe == null) return NotFound();
        return Ok(equipe);
    }

    [HttpPost]
    public IActionResult Create(Equipe equipe)
    {
        if (equipe.Participantes != null && equipe.Participantes.Count > 5)
            return BadRequest("Equipe pode ter no máximo 5 participantes.");

        _context.Equipes.Add(equipe);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = equipe.Id }, equipe);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Equipe equipeAtualizada)
    {
        var equipe = _context.Equipes
            .Include(e => e.Participantes)
            .FirstOrDefault(e => e.Id == id);

        if (equipe == null) return NotFound();

        equipe.Nome = equipeAtualizada.Nome;

        _context.Participantes.RemoveRange(equipe.Participantes!);
        equipe.Participantes = equipeAtualizada.Participantes;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var equipe = _context.Equipes
            .Include(e => e.Participantes)
            .FirstOrDefault(e => e.Id == id);

        if (equipe == null) return NotFound();

        _context.Participantes.RemoveRange(equipe.Participantes!);
        _context.Equipes.Remove(equipe);
        _context.SaveChanges();
        return NoContent();
    }
}