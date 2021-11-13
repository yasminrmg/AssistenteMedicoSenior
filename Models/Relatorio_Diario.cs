using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssistenteMedicoSenior.Models
{
    public class Relatorio_Diario //diario paciente
    {
        [Key]
        public int Cod_Diario { get; set; }
        public DateTime Data_Diario { get; set; }
        public string Sintomas { get; set; }
        public bool Cod_Questionario { get; set; }
        public Questionario_Medico Questionario_Medico { get; set; }
        [Required]
        public int Cod_Pessoa { get; set; }
        public Pessoa Paciente { get; set; }
    }
}