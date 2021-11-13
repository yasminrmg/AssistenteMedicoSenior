using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AssistenteMedicoSenior.Models
{
    public class Medico
    {        
        [Key]
        public int Cod_Medico { get; set; }
        [Required]
        [MaxLength(50)]
        public string Especialidade { get; set; }
        [Required]
        public string Crm { get; set; }
        public string Crm_Secundario { get; set; }
        [Required]
        public int Cod_Pessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}