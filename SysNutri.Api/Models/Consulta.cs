using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SysNutri.Api.Models
{
    [Table("Consulta")]
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public int ProfissionalId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataConsulta { get; set; }
        public Decimal PesoConsulta { get; set; }
        public string Detalhes { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual Cliente Cliente { get; set; }
        public List<Receita> Receitas { get; set; }
    }
}