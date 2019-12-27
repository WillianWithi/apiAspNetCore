using System;
using System.Collections.Generic;

namespace APICSHARP.Models
{
  
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int? Idade { get; set; }
        public decimal? LimiteCredito { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<string> clienteTelefone { get; set; }


    }
}
