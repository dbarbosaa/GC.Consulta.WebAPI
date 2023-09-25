using GC.Consulta.Domain.Entidade;
using GC.Consulta.Infra.Interface;
using GC.Consulta.Servico.Interface;

namespace GC.Consulta.Servico.Servico
{
    public class PessoaServico : Servico<Pessoa>, IPessoaServico
    {
        public PessoaServico(IPessoaRepositorio repository) : base(repository)
        {

        }
    }
}
