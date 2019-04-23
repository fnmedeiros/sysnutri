using SysNutri.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysNutri.Mvc
{
    public class UsuarioProfissionalViewlModel : RegisterViewModel
    {
        public string Profissao { get; set; }
        public string NroCarteira { get; set; }
    }
}