using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SysNutri.Mvc.Models
{
    public class Profissional
    {
        [Key]
        public int ProfissionalId { get; set; }
        public string Profissao { get; set; }
        public string NroCarteira { get; set; }
        public int UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        public virtual List<Receita> Receitas { get; set; }
    }
}