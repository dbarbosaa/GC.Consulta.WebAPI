using GC.Consulta.Domain.Entidade;
using GC.Consulta.Servico.Interface;

namespace GC.Consulta.WebApi.Controllers
{
    public class CargoController : Controller<Cargo>
    {
        public CargoController(ICargoServico service)  : base(service)
        {

        }
    }
}