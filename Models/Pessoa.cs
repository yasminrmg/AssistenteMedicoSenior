using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistenteMedicoSenior.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            Contatos = new Collection<Contato>();
            RelacionamentosPaciente = new Collection<Paciente_Relacionamento>();
            RelacionamentosMedico = new Collection<Paciente_Relacionamento>();
        }
        [Key]
        public int Cod_Pessoa {get;set;}
        [Required]
        [MaxLength(300)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(15)]
        public string Cpf { get; set; }
        [Required]
        [MaxLength(12)]
        public string Rg { get; set; }
        [Required]
        public DateTime Data_Nascimento { get; set; }
        [Required]
        [MaxLength(10)]
        public string Sexo { get; set; }
        [Required]
        [MaxLength(10)]
        public string Raca_Cor { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nacionalidade { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(9)]
        public string Cep { get; set; }
        [Required]
        [MaxLength(150)]

        public string Endereco { get; set; }
        [Required]
        public int Num_Endereco { get; set; }
        [MaxLength(100)]

        public string Complemento { get; set; }
        [Required]
        [MaxLength(50)]
        public string Municipio { get; set; }
        [Required]
        [MaxLength(20)]
        public string Uf { get; set; }

        /*[Required]
        [MaxLength(40)]
        public string Usuario { get; set; }*
        */
        [NotMapped]
        public string token { get; set; }
        [Required]
        public string Senha { get; set; }

        [Required]
        public int Cod_Pessoa_Tipo { get; set; }
        public Pessoa_Tipo Pessoa_Tipo { get; set; } // uma pessoa pode ter apenas um tipo de pessoa
        public ICollection<Contato> Contatos { get; set; } //uma pessoa pode ter varios contatos

        //inversao de propriedade
        [InverseProperty("Paciente")]
        public ICollection<Paciente_Relacionamento> RelacionamentosPaciente { get; set; }
        [InverseProperty("Medico")]
        public ICollection<Paciente_Relacionamento> RelacionamentosMedico { get; set; }        
    }
}