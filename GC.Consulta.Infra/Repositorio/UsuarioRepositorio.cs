using Microsoft.EntityFrameworkCore;
using GC.Consulta.Domain.Entidade;
using GC.Consulta.Infra.Context;
using GC.Consulta.Infra.Interface;

namespace GC.Consulta.Infra.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DataBaseContext context) : base(context)
        {

        }

        public async Task<Usuario> LoginPaciente(string email, string senha) => await context.Usuario.Where(e => e.Email == email && e.Senha == senha && e.Tipo==1 ).FirstOrDefaultAsync();
        public async Task<Usuario> LoginColaborador(string email, string senha) => await context.Usuario.Where(e => e.Email == email && e.Senha == senha && e.Tipo == 2).FirstOrDefaultAsync();

    }
}