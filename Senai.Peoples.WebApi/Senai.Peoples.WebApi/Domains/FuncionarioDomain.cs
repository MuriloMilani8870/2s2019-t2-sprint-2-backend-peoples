using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }
        [Required(ErrorMessage = "O Nome do Genero é obrigatório.")]
        public string NomeFuncionario { get; set; }
        public string SobrenomeFuncionario { get; set; }

    }
}
