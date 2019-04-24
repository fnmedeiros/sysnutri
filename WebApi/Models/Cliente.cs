using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int ProfissionalId { get; set; }
        public string Status { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Profissional Profissional { get; set; }
    }
}