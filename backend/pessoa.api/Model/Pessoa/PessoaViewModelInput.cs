using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa.api.Model.Pessoa
{
    public class PessoaViewModelInput
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Cpf é obrigatório")]
        public long Cpf { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Numero é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O Cep é obrigatório")]
        public int Cep { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O Numero de Telefone é obrigatório")]
        public int  NumeroTelefone { get; set; }

        [Required(ErrorMessage = "O DDD do telefone é obrigatório")]
        public int Ddd { get; set; }

        [Required(ErrorMessage = "O Tipo de Telefone é obrigatório")]
        public string Tipo { get; set; }
    }
}
