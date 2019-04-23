using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SysNutri.Api.Models
{
    [Table("Refeicao")]
    public class Refeicao
    {
        public int RefeicaoId { get; set; }
        public int ReceitaId { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public virtual Receita Receita { get; set; }
    }
}