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

        public async Task<Usuario> Validar(string email, string senha) => await context.Usuario.Where(e => e.Email == email && e.Senha == senha).FirstOrDefaultAsync();
    }
}
