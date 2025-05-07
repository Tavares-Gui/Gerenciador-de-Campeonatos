using Microsoft.EntityFrameworkCore;
using EsportsAPI.Models;

namespace EsportsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Partida> Partidas { get; set; }
    }
}
