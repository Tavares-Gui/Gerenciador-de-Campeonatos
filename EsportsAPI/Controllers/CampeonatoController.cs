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
    public IActionResult GetAll()
    {
        var campeonatos = _context.Campeonatos
            .Include(c => c.CampeonatoEquipes!)
                .ThenInclude(ce => ce.Equipe)
            .ToList();
        return Ok(campeonatos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var campeonato = _context.Campeonatos
            .Include(c => c.CampeonatoEquipes!)
                .ThenInclude(ce => ce.Equipe)
            .FirstOrDefault(c => c.Id == id);

        if (campeonato == null) return NotFound();
        return Ok(campeonato);
    }

    [HttpPost]
    public IActionResult Create(Campeonato campeonato)
    {
        _context.Campeonatos.Add(campeonato);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = campeonato.Id }, campeonato);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Campeonato campeonato)
    {
        var existing = _context.Campeonatos.Find(id);
        if (existing == null) return NotFound();

        existing.Nome = campeonato.Nome;
        existing.Data = campeonato.Data;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var campeonato = _context.Campeonatos.Find(id);
        if (campeonato == null) return NotFound();

        _context.Campeonatos.Remove(campeonato);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPost("{campeonatoId}/adicionar-equipe/{equipeId}")]
    public IActionResult AdicionarEquipe(int campeonatoId, int equipeId)
    {
        var exists = _context.CampeonatoEquipes.Any(ce =>
            ce.CampeonatoId == campeonatoId && ce.EquipeId == equipeId);

        if (exists) return BadRequest("Equipe já adicionada.");

        var relacao = new CampeonatoEquipe
        {
            CampeonatoId = campeonatoId,
            EquipeId = equipeId
        };

        _context.CampeonatoEquipes.Add(relacao);
        _context.SaveChanges();
        return Ok("Equipe adicionada.");
    }

    [HttpDelete("{campeonatoId}/remover-equipe/{equipeId}")]
    public IActionResult RemoverEquipe(int campeonatoId, int equipeId)
    {
        var relacao = _context.CampeonatoEquipes.FirstOrDefault(ce =>
            ce.CampeonatoId == campeonatoId && ce.EquipeId == equipeId);

        if (relacao == null) return NotFound();

        _context.CampeonatoEquipes.Remove(relacao);
        _context.SaveChanges();
        return Ok("Equipe removida.");
    }
}