using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICSHARP.Models
{
   
    [Table("cliente_telefone")]
    public class ClienteTelefone 
    {
        [Column("id")] 
        public int Id { get; set; }

        [Column("telefone")]
        [StringLength(11)]
        public  string Telefone{ get; set; }

        [Column("id_cliente")]
        public int? ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}