using GC.Consulta.Domain.Entidade;
using GC.Consulta.Infra.Interface;
using GC.Consulta.Servico.Interface;

namespace GC.Consulta.Servico.Servico
{
    public class CargoServico : Servico<Cargo>, ICargoServico
    {
        public CargoServico(ICargoRepositorio repository) : base(repository)
        {

        }
    }
}
