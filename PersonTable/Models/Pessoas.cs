using System.ComponentModel.DataAnnotations;

namespace PersonTable.Models
{
    public class Pessoas
    {
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(50, ErrorMessage = "O nome deve ter, no máximo 50 caracteres")]
        [Display(Name = "Nome: ")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório")]
        [StringLength(50, ErrorMessage = "O endereço deve ter, no máximo 50 caracteres")]
        [Display(Name = "Endereço: ")]
        public String Endereço { get; set; }
    }
}
