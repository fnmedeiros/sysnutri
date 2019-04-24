using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Profissional")]
    public class Profissional
    {
        [Key]
        public int ProfissionalId { get; set; }
        public int UsuarioId { get; set; }
        public string Profissao { get; set; }
        public string NroCarteira { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}