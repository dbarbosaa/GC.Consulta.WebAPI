using Microsoft.EntityFrameworkCore;
using GC.Consulta.Domain.Entidade;

namespace GC.Consulta.Infra.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) 
        {

        }
    }
}