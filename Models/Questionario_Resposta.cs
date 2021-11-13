using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistenteMedicoSenior.Models
{
    public class Questionario_Resposta //respostas
    {
        [Key]
        public string Cod_Resposta { get; set; }
        [Required]
        public string Resposta { get; set; }

        [Required]
        public int Cod_Pessoa_Paciente { get; set; } // FK de pessoa tipo paciente
        public int Cod_Pessoa_Medico { get; set; } // FK de pessoa tipo medico
        [ForeignKey("Cod_Pessoa_Paciente")]
        public Pessoa Paciente { get; set; } //referencia a tabela pessoa
        [ForeignKey("Cod_Pessoa_Medico")]
        public Pessoa Medico { get; set; } //referencia a tabela pessoa
        public int Cod_Dispositivo { get; set; }
        public Dispositivo Dispositivo { get; set; }
        public int Cod_Questionario { get; set; } //FK de Questionario_Medico
        public Questionario_Medico Questionario_Medico { get; set; }
        public int Cod_Diario { get; set; }
        public Relatorio_Diario Relatorio_Diario {get; set;}
    }
}