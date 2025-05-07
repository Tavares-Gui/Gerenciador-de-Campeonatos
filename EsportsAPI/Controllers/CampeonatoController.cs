using Microsoft.AspNetCore.Mvc;
using EsportsAPI.Data;
using EsportsAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class CampeonatoController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CampeonatoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var campeonatos = _context.Campeonatos.ToList();
        return Ok(campeonatos);
    }

    [HttpPost]
    public IActionResult Post(Campeonato campeonato)
    {
        _context.Campeonatos.Add(campeonato);
        _context.SaveChanges();
        return Created("", campeonato);
    }
}
