using Microsoft.EntityFrameworkCore;
using EsportsAPI.Models;

namespace EsportsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Participante> Participante { get; set; }
        public DbSet<CampeatoEquipe> CampeatoEquipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CampeonatoEquipe>()
                .HasKey(ce => new { ce.CampeonatoId, ce.EquipeId });

            modelBuilder.Entity<CampeonatoEquipe>()
                .HasOne(ce => ce.Campeonato);
                .WithMany(c => c.CampeonatoEquipes);
                .HasForeignKey(ce => cs.CampeonatoId);

            modelBuilder.Entity<CampeonatoEquipe>()
                .HasOne(ce => ce.Equipe);
                .WithMany(e => e.CampeonatoEquipes);
                .HasForeignKey(ce => ce.EquipeId);   
        }
    }
}
