using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AssistenteMedicoSenior.Models
{
    public class Enfermidade
    {
        public Enfermidade()
        {
            Enfermidades_Pacientes = new Collection<Enfermidade_Paciente>();
        }
        [Key]
        public int Cod_Enfermidade { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(120)]
        public string Nome_Cientifico { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Possui_Tratamento { get; set; }
        public int Cod_Deficiencia { get; set; } // FK de deficiencia
        public Deficiencia Deficiencia { get; set; }

        public ICollection<Enfermidade_Paciente> Enfermidades_Pacientes {get; set;}
    }
}