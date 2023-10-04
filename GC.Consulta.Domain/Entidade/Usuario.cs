using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GC.Consulta.Domain.Entidade.Util;

namespace GC.Consulta.Domain.Entidade
{
    [Table("Usuario", Schema = "dbo")]
    public class Usuario : Basico
    {
        [Column("Email")]
        [StringLength(50, ErrorMessage = "O campo Email deve possuir no máximo 50 caracteres"), Required(ErrorMessage = "O campo Email é obrigatório"), RegularExpression(".+\\@.+\\..+", ErrorMessage = "O email informado é inválido")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "O campo Senha deve possuir no máximo 50 caracteres")]
        public string Senha { get; set; }

        [Column("Permissao")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Permissao { get; set; }

        [Column("Tipo")]
        public int Tipo { get; set; }
    }
}