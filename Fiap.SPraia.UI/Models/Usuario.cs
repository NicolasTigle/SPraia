using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.SPraia.UI.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id"), Display(Name="Código")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date), Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }








    }
}
