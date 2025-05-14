public class Campeonato
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    
    public List<CampeonatoEquipe>? CampeonatoEquipes { get; set; }
}
