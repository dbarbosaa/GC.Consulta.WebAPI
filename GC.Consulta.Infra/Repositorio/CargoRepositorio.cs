using GC.Consulta.Domain.Entidade;
using GC.Consulta.Infra.Context;
using GC.Consulta.Infra.Interface;

namespace GC.Consulta.Infra.Repositorio
{
    public class CargoRepositorio : Repositorio<Cargo>, ICargoRepositorio
    {
        public CargoRepositorio(DataBaseContext context) : base(context)
        {

        }
    }
}
