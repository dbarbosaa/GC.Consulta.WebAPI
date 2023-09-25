using GC.Consulta.Domain.Entidade;
using GC.Consulta.Infra.Interface;
using GC.Consulta.Servico.Interface;

namespace GC.Consulta.Servico.Servico
{
    public class UsuarioServico : Servico<Usuario>, IUsuarioServico
    {
        public UsuarioServico(IUsuarioRepositorio repository) : base(repository)
        {

        }

        public async Task<Usuario> Validar(string email, string senha)
        {
            return await ((IUsuarioRepositorio)repositorio).Validar(email, senha);
        }
    }
}
