namespace EsportsAPI.Models;

public class Equipe
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public List<Participante>? Participantes { get; set; }
    public List<CampeonatoEquipe>? CampeonatoEquipes { get; set; }
}
