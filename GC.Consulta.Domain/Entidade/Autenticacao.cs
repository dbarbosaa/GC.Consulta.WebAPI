
namespace GC.Consulta.Domain.Entidade
{
    public class Autenticacao
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Usuario Usuario { get; set; }
    }
}
