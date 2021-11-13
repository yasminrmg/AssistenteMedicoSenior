using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistenteMedicoSenior.Models
{
    public class Enfermidade_Paciente
    {
        public Enfermidade_Paciente()
        {
            //Pessoas = new Collection<Pessoa>();
        }
        [Key]
        public int Cod_Enfermidade_Paciente { get; set; }
        [Required]
        public bool Ativa { get; set; }
        public string InformacoesAdicionais { get; set; }
        public DateTime Data { get; set; }

        // faz parte de chaves estrangeiras
        [Required]
        public int Cod_Pessoa_Paciente { get; set; } // FK de pessoa tipo paciente
        [Required]
        public int Cod_Pessoa_Medico { get; set; } // FK de pessoa tipo medico
        [ForeignKey("Cod_Pessoa_Paciente")]
        public Pessoa Paciente { get; set; } //referencia a tabela pessoa
        [ForeignKey("Cod_Pessoa_Medico")]
        public Pessoa Medico { get; set; } //referencia a tabela pessoa
        [Required]
        public int Cod_Enfermidade { get; set; }
        public Enfermidade Enfermidade { get; set; }
    }
}