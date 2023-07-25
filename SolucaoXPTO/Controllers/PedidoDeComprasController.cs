using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolucaoXPTO.Data;
using SolucaoXPTO.Models;

namespace SolucaoXPTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoDeComprasController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoDeComprasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PedidoDeCompras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDeCompra>>> GetPedidos()
        {
          if (_context.Pedidos == null)
          {
              return NotFound();
          }
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/PedidoDeCompras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDeCompra>> GetPedidoDeCompra(int id)
        {
          if (_context.Pedidos == null)
          {
              return NotFound();
          }
            var pedidoDeCompra = await _context.Pedidos.FindAsync(id);

            if (pedidoDeCompra == null)
            {
                return NotFound();
            }

            return pedidoDeCompra;
        }

        // PUT: api/PedidoDeCompras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoDeCompra(int id, PedidoDeCompra pedidoDeCompra)
        {
            if (id != pedidoDeCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoDeCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoDeCompraExists(id))
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

        // POST: api/PedidoDeCompras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoDeCompra>> PostPedidoDeCompra(PedidoDeCompra pedidoDeCompra)
        {
          if (_context.Pedidos == null)
          {
              return Problem("Entity set 'DataContext.Pedidos'  is null.");
          }
            _context.Pedidos.Add(pedidoDeCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoDeCompra", new { id = pedidoDeCompra.Id }, pedidoDeCompra);
        }

        // DELETE: api/PedidoDeCompras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoDeCompra(int id)
        {
            if (_context.Pedidos == null)
            {
                return NotFound();
            }
            var pedidoDeCompra = await _context.Pedidos.FindAsync(id);
            if (pedidoDeCompra == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedidoDeCompra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoDeCompraExists(int id)
        {
            return (_context.Pedidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
