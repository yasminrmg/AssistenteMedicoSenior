using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistenteMedicoSenior.Models
{
    public class Receituario
    {
        [Key]
        public int Cod_Receituario { get; set; }  
        [Required]
        public string Medicamento { get; set; }
        [Required]
        [MaxLength(50)]
        public string Dosagem { get; set; }
        [Required]
        public string Intervalo_Horas { get; set; }
        [Required]
        public DateTime Inicio { get; set; }
        [Required]        
        public DateTime Fim { get; set; }
        [DefaultValue(true)]
        public bool Lembrete { get; set; }

        [Required]
        public int Cod_Consulta { get; set; } // FK de consulta
        public Consulta Consulta { get; set; }
        public int Cod_Enfermidade { get; set; }
        public Enfermidade Enfermidade  { get; set; }     
        [Required]
        public int Cod_Pessoa_Paciente { get; set; } // FK de pessoa tipo paciente
        [Required]
        public int Cod_Pessoa_Medico { get; set; } // FK de pessoa tipo medico
        [ForeignKey("Cod_Pessoa_Paciente")]
        public Pessoa Paciente { get; set; } //referencia a tabela pessoa
        [ForeignKey("Cod_Pessoa_Medico")]
        public Pessoa Medico { get; set; } //referencia a tabela pessoa
        
    }
}