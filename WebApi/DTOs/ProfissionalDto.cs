using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTOs
{
    public class ProfissionalDto
    {
        public int ProfissionalId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Profissao { get; set; }
        public string NroCarteira { get; set; }
    }
}