using GC.Consulta.Domain.Entidade;

namespace GC.Consulta.Infra.Interface
{
    public interface IEnderecoRepositorio 
    {
        Task<Endereco> Salvar(Endereco endereco);
        Task<Endereco> BuscarPorId(long id);
    }
}
