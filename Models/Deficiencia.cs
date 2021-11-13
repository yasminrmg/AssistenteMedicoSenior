using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AssistenteMedicoSenior.Models
{
    public class Deficiencia
    {
        public Deficiencia()
        {
            Enfermidades = new Collection<Enfermidade>();
        }
        [Key]
        public int Cod_Deficiencia { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome_Deficiencia { get; set; }
        public ICollection<Enfermidade> Enfermidades { get; set; } 
    }
}