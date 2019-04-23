using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SysNutri.Mvc.Models
{
    public class Receita
    {
        [Key]
        public int ReceitaId { get; set; }
        public int ClienteId { get; set; }
        public int ProfissionalId { get; set; }
        public DateTime DataReceita { get; set; }
        public string Descricao { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual List<Refeicao> Refeicoes { get; set; }
    }
}