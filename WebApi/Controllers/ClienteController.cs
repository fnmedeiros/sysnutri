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
    }
}
