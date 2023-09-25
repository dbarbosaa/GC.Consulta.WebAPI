using GC.Consulta.Domain.Entidade.Util;

namespace GC.Consulta.Domain.Entidade.DTO
{
    public class FiltroPedidoDTO : FiltroBase
    {
        public FiltroPedidoDTO()
        {

        }
        public long[] EmpresaId { get; set; }
        public long[] ObraId { get; set; }
        public long[] CentroCustoId { get; set; }
        public bool Urgente { get; set; }
        public DateTime? DataInicioEntrega { get; set; }
        public DateTime? DataFimEntrega { get; set; }
        public DateTime? DataInicioDevolutiva { get; set; }
        public DateTime? DataFimDevolutiva { get; set; }
    }
}
