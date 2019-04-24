using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DTOs;
using WebApi.Lib;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private SysNutriContext db = new SysNutriContext();

        private bool ExisteCliente(int id)
        {
            var cliente = db.Clientes.Where(p => p.ClienteId == id).FirstOrDefault();

            return cliente != null;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetClientes()
        {
            List<Cliente> clientes = db.Clientes.ToList();
            List<ClienteDto> clienteDto = new List<ClienteDto>();
            foreach (var item in clientes)
            {
                clienteDto.Add(new ClienteDto()
                {
                    ClienteId = item.ClienteId,
                    ProfissionalId = item.ProfissionalId,
                    UsuarioId = item.UsuarioId,
                    Nome = item.Usuario.Nome,
                    Sobrenome = item.Usuario.Sobrenome,
                    Cpf = item.Usuario.Cpf,
                    Email = item.Usuario.Email,
                    Senha = item.Usuario.Senha,
                    Status = item.Status
                });
            }

            return Ok(clienteDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetClientePorId(int id)
        {
            Cliente cliente = new Cliente();
            ClienteDto clienteDto = new ClienteDto();

            if (ExisteCliente(id))
            {
                cliente = db.Clientes.Where(p => p.ClienteId == id).FirstOrDefault();

                clienteDto.ClienteId = cliente.ClienteId;
                clienteDto.ProfissionalId = cliente.ProfissionalId;
                clienteDto.UsuarioId = cliente.UsuarioId;
                clienteDto.Nome = cliente.Usuario.Nome;
                clienteDto.Sobrenome = cliente.Usuario.Sobrenome;
                clienteDto.Email = cliente.Usuario.Email;
                clienteDto.Senha = cliente.Usuario.Senha;
                clienteDto.Cpf = cliente.Usuario.Cpf;
                clienteDto.Status = cliente.Status;
                return Ok(clienteDto);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult PostCliente(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Usuario usuario = new Usuario();

            HashCustom hashCustom = new HashCustom();

            usuario.Nome = clienteDto.Nome;
            usuario.Sobrenome = clienteDto.Sobrenome;
            usuario.Email = clienteDto.Email;
            usuario.Cpf = clienteDto.Cpf;
            usuario.Senha = hashCustom.HashMd5(clienteDto.Senha.Trim());

            var novoUsuario = db.Usuarios.Add(usuario);

            Cliente cliente = new Cliente();

            cliente.UsuarioId = novoUsuario.UsuarioId;
            cliente.ProfissionalId = clienteDto.ProfissionalId;
            cliente.Status = clienteDto.Status;

            db.Clientes.Add(cliente);
            db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult ClientelLogin(LoginDto login)
        {
            Cliente cliente = new Cliente();

            HashCustom hashCustom = new HashCustom();

            cliente = db.Clientes.Where(p => p.Usuario.Email == login.email).FirstOrDefault();
            var senhaCrip = hashCustom.HashMd5(login.senha.Trim());
            if (cliente.Usuario.Senha != "")
            {
                if (cliente.Usuario.Senha.Trim() == senhaCrip)
                {
                    return Ok();
                }
            }
            return BadRequest("Email ou senha incorretos!");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult PutCliente(int id, [FromBody] ClienteDto dto)
        {

            if (ExisteCliente(id))
            {
                Cliente cliente = db.Clientes.Where(p => p.ClienteId == id).FirstOrDefault();
                Usuario usuario = cliente.Usuario;

                cliente.Status = dto.Status;

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
        public IHttpActionResult DeleteCliente(int id)
        {

            if (ExisteCliente(id))
            {
                Cliente cliente = db.Clientes.Where(p => p.ClienteId == id).FirstOrDefault();
                Usuario usuario = cliente.Usuario;

                db.Clientes.Remove(cliente);
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
