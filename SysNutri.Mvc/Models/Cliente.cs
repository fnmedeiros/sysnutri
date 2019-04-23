using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SysNutri.Mvc.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int PsofissionalId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual List<Receita> Receitas { get; set; }
    }
}