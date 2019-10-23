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
    public class ProdCategoriaProductoController : ControllerBase
    {
        private readonly OuletBDContext _context;

        public ProdCategoriaProductoController(OuletBDContext context)
        {
            _context = context;
        }

        // GET: api/ProdCategoriaProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdCategoriaProducto>>> GetProdCategoriaProducto()
        {
            return await _context.ProdCategoriaProducto.ToListAsync();
        }

        // GET: api/ProdCategoriaProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdCategoriaProducto>> GetProdCategoriaProducto(int id)
        {
            var prodCategoriaProducto = await _context.ProdCategoriaProducto.FindAsync(id);

            if (prodCategoriaProducto == null)
            {
                return NotFound();
            }

            return prodCategoriaProducto;
        }

        // PUT: api/ProdCategoriaProducto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdCategoriaProducto(int id, ProdCategoriaProducto prodCategoriaProducto)
        {
            if (id != prodCategoriaProducto.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(prodCategoriaProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdCategoriaProductoExists(id))
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

        // POST: api/ProdCategoriaProducto
        [HttpPost]
        public async Task<ActionResult<ProdCategoriaProducto>> PostProdCategoriaProducto(ProdCategoriaProducto prodCategoriaProducto)
        {
            _context.ProdCategoriaProducto.Add(prodCategoriaProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdCategoriaProducto", new { id = prodCategoriaProducto.CategoriaId }, prodCategoriaProducto);
        }

        // DELETE: api/ProdCategoriaProducto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdCategoriaProducto>> DeleteProdCategoriaProducto(int id)
        {
            var prodCategoriaProducto = await _context.ProdCategoriaProducto.FindAsync(id);
            if (prodCategoriaProducto == null)
            {
                return NotFound();
            }

            _context.ProdCategoriaProducto.Remove(prodCategoriaProducto);
            await _context.SaveChangesAsync();

            return prodCategoriaProducto;
        }

        private bool ProdCategoriaProductoExists(int id)
        {
            return _context.ProdCategoriaProducto.Any(e => e.CategoriaId == id);
        }
    }
}
