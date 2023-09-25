namespace GC.Consulta.Domain.Entidade.Util
{
    public class ListaPaginada<T>
    {
        public decimal Total { get; private set; }
        public decimal TotalPorPagina { get; private set; }
        public int Pagina { get; private set; }

        public decimal TotalPaginas
        {
            get { return Math.Ceiling(Total / TotalPorPagina); }
        }

        public List<T> Itens { get; private set; }

        public ListaPaginada(List<T> itens, int totalItens, int itensPorPagina, int paginaAtual)
        {
            Itens = itens;
            Total = totalItens;
            TotalPorPagina = itensPorPagina;
            Pagina = paginaAtual;
        }

    }
}
