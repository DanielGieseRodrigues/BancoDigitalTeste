using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSide.Models;


namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly BancoDigitalContext _context;

        public ClientesController(BancoDigitalContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        public async Task<IActionResult> Get(string login, string senha)
        {
            //Verifica se tem um usuário com essa senha e login,se tiver retorna-o.
            if (!ModelState.IsValid)
                return BadRequest();

            var usuarios = _context.Clientes.Where(p => p.Usuário == login && p.Senha == senha);

            if (usuarios.Count() > 0)
            {
                var result = await Task.FromResult(usuarios.Where(p => p.Usuário == login && p.Senha == senha));
                return Ok(result);
            }
                
            else
                return Ok(new Clientes());
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientes(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Cliente = await Task.FromResult(_context.Clientes.Where(p=> p.Idcliente == id));

            if (Cliente == null)
            {
                return NotFound();
            }

            return Ok(Cliente);
        }

        // POST: api/Clientes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

       

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
