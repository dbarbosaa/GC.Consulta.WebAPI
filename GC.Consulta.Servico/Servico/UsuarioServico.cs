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

        public async Task<Usuario> LoginPaciente(string email, string senha)
        {
            return await ((IUsuarioRepositorio)repositorio).LoginPaciente(email, senha);
        }
        public async Task<Usuario> LoginColaborador(string email, string senha)
        {
            return await ((IUsuarioRepositorio)repositorio).LoginColaborador(email, senha);
        }
    }
}
