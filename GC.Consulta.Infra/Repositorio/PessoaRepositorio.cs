using GC.Consulta.Domain.Entidade;
using GC.Consulta.Infra.Context;
using GC.Consulta.Infra.Interface;

namespace GC.Consulta.Infra.Repositorio
{
    public class PessoaRepositorio : Repositorio<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(DataBaseContext context) : base(context)
        {

        }
    }
}
