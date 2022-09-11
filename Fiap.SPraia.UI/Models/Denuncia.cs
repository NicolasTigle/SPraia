using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.SPraia.UI.Models
{
    [Table("Denuncia")]
    public class Denuncia
    {
        [Column("Id"), Display(Name = "Código")]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public String Praia { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public Status Status { get; set; }
        [DataType(DataType.Date), Display(Name = "Data da Denúncia")]
        public DateTime DataCriacao { get; set; }

    }
}
