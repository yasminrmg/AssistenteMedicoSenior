using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssistenteMedicoSenior.Models
{
    public class Contato
    {
        [Key]
        public int Cod_Contato { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public bool Emergencia { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }
        [Required]
        public int Cod_Pessoa { get; set; } //chave estrangeira
        public virtual Pessoa Pessoa { get; set; }
    }
}