using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsportsAPI.Data;
using EsportsAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class EquipeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EquipeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var equipes = _context.Equipes
            .Include(e => e.Participantes)
            .Include(e => e.CampeonatoEquipes)
                .ThenInclude(ce => ce.Campeonato)
            .ToList();

        return Ok(equipes);
    }

    [HttpPost]
    public IActionResult Post(Equipe equipe)
    {
        if (equipe.Participantes?.Count > 5)
        {
            return BadRequest("A equipe pode ter no máximo 5 participantes.");
        }

        _context.Equipes.Add(equipe);
        _context.SaveChanges();
        return Created("", equipe);
    }
}
