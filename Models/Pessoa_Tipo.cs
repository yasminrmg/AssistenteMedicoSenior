using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssistenteMedicoSenior.Models
{
    public class Pessoa_Tipo
    {
        public Pessoa_Tipo()
        {
            Pessoas = new Collection<Pessoa>();
        }
        [Key]
        public int Cod_Pessoa_Tipo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome_Tipo { get; set; }
        [DefaultValue(true)]
        public bool Tipo_ativo { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; } //um tipo pessoa pode ter varias pessoas
    }
}