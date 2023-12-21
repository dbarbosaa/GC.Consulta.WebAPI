using GC.Consulta.Domain.Entidade;
using GC.Consulta.Servico.Interface;

namespace GC.Consulta.WebApi.Controllers
{
    public class PessoaController : Controller<Pessoa>
    {

        public PessoaController(IPessoaServico service)  : base(service)
        {

        }
    }
}