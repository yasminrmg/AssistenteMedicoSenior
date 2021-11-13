using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistenteMedicoSenior.Models
{
    public class Consulta
    {
        public Consulta()
        {
            Receitas = new Collection<Receituario>();
        }
        [Key]
        public int Cod_Consulta { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public DateTime Data_Registro { get; set; }
        public bool Confirmado { get; set; }
        public bool Realizada { get; set; }
        public string Relatorio { get; set; } //relatorio do médico com informações da consulta realizada
        public string Resumo_Saude { get; set; } //desde a ultima consulta
        public int Criador { get; set; }
        [DefaultValue(true)]
        public bool Lembrete { get; set; }

        // faz parte de chaves estrangeiras
        [Required]
        public int Cod_Pessoa_Paciente { get; set; } // FK de pessoa tipo paciente
        [Required]
        public int Cod_Pessoa_Medico { get; set; } // FK de pessoa tipo medico
        [ForeignKey("Cod_Pessoa_Paciente")]
        public Pessoa Paciente { get; set; } //referencia a tabela pessoa
        [ForeignKey("Cod_Pessoa_Medico")]
        public Pessoa Medico { get; set; } //referencia a tabela pessoa
        public ICollection<Receituario> Receitas { get; set; }
    }
}