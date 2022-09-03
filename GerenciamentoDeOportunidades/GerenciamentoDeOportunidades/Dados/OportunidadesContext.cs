


using Microsoft.EntityFrameworkCore;


namespace GerenciamentoDeOportunidades.Dados
{
    public partial class OportunidadesContext : DbContext
    {
        protected readonly IConfiguration Config;
        protected readonly string stringDeConexao = "data source=POSCCIS;initial catalog=Oportunidades;trusted_connection=true";

        public OportunidadesContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(stringDeConexao);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }


        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Oportunidade> oportunidades { get; set; }
    }
}
