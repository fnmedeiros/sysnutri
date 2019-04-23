using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTOs
{
    public class LoginDto
    {
        public string email { get; set; }
        public string senha { get; set; }
    }
}