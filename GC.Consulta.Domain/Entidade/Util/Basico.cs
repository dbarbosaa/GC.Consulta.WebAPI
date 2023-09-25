using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GC.Consulta.Domain.Entidade.Util
{
    public class Basico
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("Nome")]
        public string? Nome { get; set; }

        [Column("Usuario_Alteracao_Id")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [JsonIgnore]
        public long UsuarioAlteracaoId { get; set; }

        [JsonIgnore]
        [Column("Data_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonIgnore]
        [Column("Data_Alteracao")]
        public DateTime? DataAlteracao { get; set; }

        [Column("Status")]
        public int Status { get; set; }

    }
}
