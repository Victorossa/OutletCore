using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutletCore.Models;

namespace OutletCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdTipoProductoController : ControllerBase
    {
        private readonly OuletBDContext _context;

        public ProdTipoProductoController(OuletBDContext context)
        {
            _context = context;
        }

        // GET: api/ProdTipoProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdTipoProducto>>> GetProdTipoProducto()
        {
            return await _context.ProdTipoProducto.ToListAsync();
        }

        // GET: api/ProdTipoProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdTipoProducto>> GetProdTipoProducto(int id)
        {
            var prodTipoProducto = await _context.ProdTipoProducto.FindAsync(id);

            if (prodTipoProducto == null)
            {
                return NotFound();
            }

            return prodTipoProducto;
        }

        // PUT: api/ProdTipoProducto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdTipoProducto(int id, ProdTipoProducto prodTipoProducto)
        {
            if (id != prodTipoProducto.TipoProductoId)
            {
                return BadRequest();
            }

            _context.Entry(prodTipoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdTipoProductoExists(id))
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

        // POST: api/ProdTipoProducto
        [HttpPost]
        public async Task<ActionResult<ProdTipoProducto>> PostProdTipoProducto(ProdTipoProducto prodTipoProducto)
        {
            _context.ProdTipoProducto.Add(prodTipoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdTipoProducto", new { id = prodTipoProducto.TipoProductoId }, prodTipoProducto);
        }

        // DELETE: api/ProdTipoProducto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdTipoProducto>> DeleteProdTipoProducto(int id)
        {
            var prodTipoProducto = await _context.ProdTipoProducto.FindAsync(id);
            if (prodTipoProducto == null)
            {
                return NotFound();
            }

            _context.ProdTipoProducto.Remove(prodTipoProducto);
            await _context.SaveChangesAsync();

            return prodTipoProducto;
        }

        private bool ProdTipoProductoExists(int id)
        {
            return _context.ProdTipoProducto.Any(e => e.TipoProductoId == id);
        }
    }
}
