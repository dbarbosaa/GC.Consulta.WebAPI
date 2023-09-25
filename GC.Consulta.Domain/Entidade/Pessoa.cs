using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GC.Consulta.Domain.Entidade.Util;
using System.Text.Json.Serialization;

namespace GC.Consulta.Domain.Entidade
{
    [Table("Pessoa", Schema = "dbo")]
    public class Pessoa : Basico
    {
        [Column("Endereco_Id")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long? EnderecoId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Endereco? Endereco { get; set; }

        [Column("Documento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Documento { get; set; }

        [Column("Habilitacao")]
        public string Habilitacao { get; set; }

        [Column("Sexo")]
        public string Sexo { get; set; }

        [Column("Data_Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Column("Telefone_1")]
        public string Telefone1 { get; set; }

        [Column("Telefone_2")]
        public string Telefone2 { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Nome_Titular_Conta")]
        public string NomeTitularConta { get; set; }

        [Column("Conta")]
        public string Conta { get; set; }

        [Column("Agencia")]
        public string Agencia { get; set; }

        [Column("Pix")]
        public string Pix { get; set; }
    }
}
