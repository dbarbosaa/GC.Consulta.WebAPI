using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GC.Consulta.Domain.Entidade
{
    [Table("Endereco", Schema = "dbo")]
    public class Endereco 
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }


        [Column("Logradouro")]
        public string Logradouro { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }


        [Column("Complemento")]
        public string Complemento { get; set; }


        [Column("Bairro")]
        public string Bairro { get; set; }


        [Column("Cidade")]
        public string Cidade { get; set; }

        [Column("UF")]
        public string UF { get; set; }


        [Column("latitude")]
        public string? Latitude { get; set; }


        [Column("longitude")]
        public string? Longitude { get; set; }
    }
}
