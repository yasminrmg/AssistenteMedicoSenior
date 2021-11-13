using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistenteMedicoSenior.Models
{
    public class Questionario_Medico//perguntas
    {
        public Questionario_Medico()
        {
            Respostas_Questionarios = new Collection<Questionario_Resposta>();
        }
        [Key]
        public int Cod_Questionario { get; set; }
        [DefaultValue(false)]
        public bool Dispositivo { get; set; } //questao pode ser preenchida via smartwatch
        [Required]
        [MaxLength(300)]
        public string Questao { get; set; }
        public bool Ativa { get; set; }
        [Required]
        public int Cod_Pessoa_Medico { get; set; } // FK de pessoa tipo medico
        public int? Cod_Pessoa_Paciente { get; set; } // FK de pessoa tipo paciente
        public int? Cod_Enfermidade { get; set; } //FK de enfermidade
        [ForeignKey("Cod_Pessoa_Medico")]
        public Pessoa Medico { get; set; } //referencia a tabela pessoa
        [ForeignKey("Cod_Pessoa_Paciente")]
        public Pessoa Paciente { get; set; } //referencia a tabela pessoa
        public Enfermidade Enfermidade  { get; set; }
        public ICollection<Questionario_Resposta> Respostas_Questionarios { get; set; }
    }
}