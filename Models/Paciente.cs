using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace AssistenteMedicoSenior.Models
{
    public class Paciente
    {
        public Paciente()
        {
            Consultas = new Collection<Consulta>();
            Enfermidades = new Collection<Enfermidade_Paciente>();
            Paciente_Relacionamentos = new Collection<Paciente_Relacionamento>();
            Relatorio_Diarios = new Collection<Relatorio_Diario>();
        }
        [Key]
        public int Cod_Paciente { get; set; }
        [Required]
        public float Altura { get; set; }
        [Required]
        public float Peso { get; set; }

        [Required]
        public int Cod_Pessoa { get; set; }
        public Pessoa Pessoa { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
        public virtual ICollection<Enfermidade_Paciente> Enfermidades { get; set; }
        public virtual ICollection<Paciente_Relacionamento> Paciente_Relacionamentos { get; set; }
        public virtual ICollection<Relatorio_Diario> Relatorio_Diarios { get; set; }
    }
}