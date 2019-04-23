using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.DTOs;
using WebApi.Lib;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/profissional")]
    public class ProfissionalController : ApiController
    {
        private SysNutriContext db = new SysNutriContext();

        private bool ExisteProfissional(int id)
        {
            var profissional = db.Profissionais.Where(p => p.ProfissionalId == id).FirstOrDefault();

            return profissional != null;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetProficionais()
        {
            List<ProfissionalDto> profissionalDto = new List<ProfissionalDto>();
            List<Profissional> profisssionais = db.Profissionais.ToList();
            foreach (var item in profisssionais)
            {
                profissionalDto.Add(new ProfissionalDto(){
                   ProfissionalId = item.ProfissionalId,
                   Profissao = item.Profissao,
                   NroCarteira = item.NroCarteira,
                   UsuarioId = item.UsuarioId,
                   Nome = item.Usuario.Nome,
                   Sobrenome = item.Usuario.Sobrenome,
                   Cpf = item.Usuario.Cpf,
                   Email = item.Usuario.Email,
                   Senha = item.Usuario.Senha
                });
            }

            return Ok(profissionalDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetProficionalPorId(int id)
        {
            Profissional profissional = new Profissional();
            ProfissionalDto profissionalDto = new ProfissionalDto();

            if (ExisteProfissional(id))
            {
                profissional = db.Profissionais.Where(p => p.ProfissionalId == id).FirstOrDefault();
                profissionalDto.ProfissionalId = profissional.ProfissionalId;
                profissionalDto.UsuarioId = profissional.UsuarioId;
                profissionalDto.Nome = profissional.Usuario.Nome;
                profissionalDto.Sobrenome = profissional.Usuario.Sobrenome;
                profissionalDto.Email = profissional.Usuario.Email;
                profissionalDto.Senha = profissional.Usuario.Senha;
                profissionalDto.Cpf = profissional.Usuario.Cpf;
                profissionalDto.Profissao = profissional.Profissao;
                profissionalDto.NroCarteira = profissional.NroCarteira;
                return Ok(profissionalDto);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostProfissional(ProfissionalDto profissionalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Usuario usuario = new Usuario();

            HashCustom hashCustom = new HashCustom();

            usuario.Nome = profissionalDto.Nome;
            usuario.Sobrenome = profissionalDto.Sobrenome;
            usuario.Email = profissionalDto.Email;
            usuario.Cpf = profissionalDto.Cpf;
            usuario.Senha = hashCustom.HashMd5(profissionalDto.Senha.Trim());

            var novoUsuario = db.Usuarios.Add(usuario);

            Profissional profissional = new Profissional();

            profissional.UsuarioId = novoUsuario.UsuarioId;
            profissional.Profissao = profissionalDto.Profissao;
            profissional.NroCarteira = profissionalDto.NroCarteira;

            db.Profissionais.Add(profissional);
            db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult ProfissionalLogin(LoginDto login)
        {
            Profissional profissional = new Profissional();

            HashCustom hashCustom = new HashCustom();

            profissional = db.Profissionais.Where(p => p.Usuario.Email == login.email).FirstOrDefault();
            var senhaCrip = hashCustom.HashMd5(login.senha.Trim());
            if (profissional.Usuario.Senha != "")
            {
                if (profissional.Usuario.Senha.Trim() == senhaCrip)
                {
                    return Ok();
                }
            }
            return BadRequest("Email ou senha incorretos!");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult PutProfissional(int id, [FromBody] ProfissionalDto dto)
        {

            if (ExisteProfissional(id))
            {
                Profissional profissional = db.Profissionais.Where(p => p.ProfissionalId == id).FirstOrDefault();
                Usuario usuario = profissional.Usuario;

                profissional.Profissao = dto.Profissao;
                profissional.NroCarteira = dto.NroCarteira;

                usuario.Nome = dto.Nome;
                usuario.Sobrenome = dto.Sobrenome;
                usuario.Email = dto.Email;
                usuario.Senha = dto.Senha;
                usuario.Cpf = dto.Cpf;

                db.SaveChanges();

                return Ok(dto);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteProfissional(int id)
        {

            if (ExisteProfissional(id))
            {
                Profissional profissional = db.Profissionais.Where(p => p.ProfissionalId == id).FirstOrDefault();
                Usuario usuario = profissional.Usuario;
                var profissionalId = profissional.ProfissionalId;
                var usuarioId = profissional.UsuarioId;

                db.Profissionais.Remove(profissional);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
