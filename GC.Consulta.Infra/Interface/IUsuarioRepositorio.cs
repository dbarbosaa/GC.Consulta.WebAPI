using GC.Consulta.Domain.Entidade;

namespace GC.Consulta.Infra.Interface
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> LoginPaciente(string email, string senha);

        Task<Usuario> LoginColaborador(string email, string senha);

    }
}
