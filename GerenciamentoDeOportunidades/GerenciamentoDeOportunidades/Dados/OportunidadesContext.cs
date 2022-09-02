using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeOportunidades
{
    public class OportunidadesContext : DbContext
    {
        protected readonly IConfiguration Config;
        protected readonly string stringDeConexao = "data source=POSCCIS;initial catalog=Oportunidades;trusted_connection=true";

        public OportunidadesContext() 
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            options.UseSqlServer(stringDeConexao);
        }

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Oportunidade> oportunidades { get; set; }
    }
}
