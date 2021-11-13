using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssistenteMedicoSenior.Models
{
    public class Credencial
    {
        [Required]
        [MaxLength(15)]
        public string cpf { get; set; }
        [Required]
        public string senha { get; set; }
    }
}
