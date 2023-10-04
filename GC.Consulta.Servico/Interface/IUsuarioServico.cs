using GC.Consulta.Domain.Entidade;

namespace GC.Consulta.Servico.Interface
{
    public interface IUsuarioServico : IServico<Usuario>
    {
        Task<Usuario> LoginPaciente(string email, string senha);
        Task<Usuario> LoginColaborador(string email, string senha);

    }
}
