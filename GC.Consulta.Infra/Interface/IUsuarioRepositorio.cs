using GC.Consulta.Domain.Entidade;

namespace GC.Consulta.Infra.Interface
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> Validar(string email, string senha);
    }
}
