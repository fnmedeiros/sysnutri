using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SysNutri.Api.Models
{
    [Table("Receita")]
    public class Receita
    {
        public int ReceitaId { get; set; }
        public int ConsultaId { get; set; }
        public DateTime DataReceita { get; set; }
        public string Descricao { get; set; }
        public List<Refeicao> Refeicoes { get; set; }
        public virtual Consulta Consulta { get; set; }
    }
}