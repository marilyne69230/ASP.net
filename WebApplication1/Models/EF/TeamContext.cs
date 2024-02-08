using Microsoft.EntityFrameworkCore;

namespace FrontalMVC.Models.EF
{
    public class TeamContext:DbContext
    {
        private IConfiguration _config;
        public TeamContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Equipe> Equipes { get; set; }

        public DbSet <joueur> Joueurs { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["Cnx"]);
        }
    }
}
