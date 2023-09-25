using GC.Consulta.Domain.Entidade.Util;

namespace GC.Consulta.Domain.Entidade.DTO
{
    public class FiltroObraDTO : FiltroBase
    {
        public string Identificador { get; set; }
        public DateTime? DataInicioTermino { get; set; }
        public DateTime? DataFimTermino { get; set; }

    }
}
