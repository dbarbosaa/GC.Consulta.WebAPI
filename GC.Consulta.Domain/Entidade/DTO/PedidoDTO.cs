namespace GC.Consulta.Domain.Entidade.DTO
{
    public class PedidoDTO
    {
        public long ObraId { get; set; }
        public long CentroCustoId { get; set; }
        public long PedidoId { get; set; }
        public long ItemPedidoId { get; set; }
        public long? TipoPedidoId { get; set; }
        public long? ProdutoId { get; set; }
        public long? TercerizadoId { get; set; }
        public long? TipoLocacaoId { get; set; }
        public decimal? Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataLancamento { get; set; }
        public DateTime? DataLimiteEntrega { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Observacao { get; set; }
        public bool Urgente { get; set; }
        public int Status { get; set; }

    }
}
