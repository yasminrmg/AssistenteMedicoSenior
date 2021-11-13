using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssistenteMedicoSenior.Models
{
    public class Dispositivo
    {
        [Key]
        public int Cod_Dispositivo { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apelido_Dispositivo { get; set; }
        public string Cod_Dispositivo_Smartphone { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }
        public DateTime Data {get; set;}
        [Required]
        public int Cod_Pessoa { get; set; }
        public Pessoa Pessoa { get; set; }
        
    }
}