using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SysNutri.Api.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int ProfissionalId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Profissional Profissional { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}