public class Jogador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Nickname { get; set; }
    public string Funcao { get; set; }
    public int TimeId { get; set; }
    public Time? Time { get; set; }
}
