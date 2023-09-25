using GC.Consulta.Domain.Entidade;
using GC.Consulta.Servico.Interface;

namespace GC.Consulta.WebApi.Controllers
{
    public class UsuarioController : Controller<Usuario>
    {
        public UsuarioController(IUsuarioServico service)  : base(service)
        {

        }
    }
}