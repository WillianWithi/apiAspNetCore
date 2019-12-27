using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICSHARP.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("idade")]
        public int? Idade { get; set; }

        [Column("limite_credito")]
        public decimal? LimiteCredito { get; set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }

        
    }
}
