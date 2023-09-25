using GC.Consulta.Domain.Entidade;

namespace GC.Consulta.Servico.Interface
{
    public interface IUsuarioServico : IServico<Usuario>
    {
        Task<Usuario> Validar(string email, string senha);
    }
}
