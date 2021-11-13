using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistenteMedicoSenior.Models
{
    public class Paciente_Relacionamento
    {
        [Key]
        public int Codigo_Relacionamento { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        [Required]
        public int? Cod_Pessoa_Paciente { get; set; } // FK de pessoa tipo paciente
        [ForeignKey("Cod_Pessoa_Paciente")]
        public virtual Pessoa Paciente { get; set; } //referencia a tabela pessoa
        [Required]
        public int? Cod_Pessoa_Medico { get; set; } // FK de pessoa tipo medico
        [ForeignKey("Cod_Pessoa_Medico")]
        public virtual Pessoa Medico { get; set; } //referencia a tabela pessoa

    }
}