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
    public class EmprestimoesController : ControllerBase
    {
        private readonly BancoDigitalContext _context;

        public EmprestimoesController(BancoDigitalContext context)
        {
            _context = context;
        }

   
        // PUT: api/Emprestimos?id=5
        public  IActionResult GetEmprestimos(int id, string value)
        {
            decimal valor = 0;
            Decimal.TryParse(value, out valor);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Empréstimo cliente
            Clientes usuario = _context.Clientes.Find(id);

            //chega limite
            if (usuario.LimiteEmprestimo - valor >= 0)
            {
                //Altera valor limite do usr.
                usuario.LimiteEmprestimo -= Convert.ToInt32(value);
                var Emprestimo = new Emprestimo { Cliente = id, Valor = valor, DataEmprestimo = DateTime.Now };
                _context.Emprestimo.Add(Emprestimo);

                _context.SaveChanges();

                var Cliente = Task.FromResult(_context.Clientes.Where(p => p.Idcliente == id));

                return Ok();
            }
            else
            {
                return BadRequest("Você não tem mais limite para empréstimos!");
            }
        }


        // PUT: api/Emprestimoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmprestimo([FromRoute] int id, [FromBody] Emprestimo emprestimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emprestimo.IdEmprestimo)
            {
                return BadRequest();
            }

            _context.Entry(emprestimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprestimoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Emprestimoes
        [HttpPost]
        public async Task<IActionResult> PostEmprestimo([FromBody] Emprestimo emprestimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Emprestimo.Add(emprestimo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmprestimoExists(emprestimo.IdEmprestimo))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmprestimo", new { id = emprestimo.IdEmprestimo }, emprestimo);
        }

        // DELETE: api/Emprestimoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmprestimo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimo.Remove(emprestimo);
            await _context.SaveChangesAsync();

            return Ok(emprestimo);
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimo.Any(e => e.IdEmprestimo == id);
        }
    }
}