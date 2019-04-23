using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SysNutri.Mvc.Models
{
    public class Refeicao
    {
        [Key]
        public int RefeicaoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public virtual Receita Receita { get; set; }
    }
}