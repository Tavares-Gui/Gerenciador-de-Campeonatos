public class Partida
{
    public int Id { get; set; }
    public int CampeonatoId { get; set; }
    public Campeonato? Campeonato { get; set; }
    public int TimeAId { get; set; }
    public int TimeBId { get; set; }
    public DateTime Data { get; set; }
    public string Resultado { get; set; }
}
