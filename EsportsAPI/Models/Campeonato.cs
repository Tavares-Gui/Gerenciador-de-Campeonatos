namespace EsportsAPI.Models
{
    public class CampeonatoEquipe
    {
        public int CampeonatoId { get; set; }
        public Campeonato? Campeonato { get; set; }

        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }
    }
}