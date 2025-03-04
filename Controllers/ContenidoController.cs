using ContentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ContentAPI.Controllers
{
    [Route("api/[controller]")]

    /// <summary>
    /// Controlador para gestionar contenidos.
    /// </summary>
    [ApiController]
    public class ContenidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContenidoController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los contenidos almacenados.
        /// </summary>
        /// <returns>Una lista de contenidos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contenido>>> GetContenidos()
        {
            return await _context.Contenidos.ToListAsync();
        }

        /// <summary>
        /// Crea un nuevo contenido.
        /// </summary>
        /// <param name="contenido">Datos del contenido a crear.</param>
        /// <returns>El contenido recién creado.</returns>
        /// <response code="201">Devuelve el contenido creado.</response>
        /// <response code="400">Si los datos son inválidos.</response>
        [HttpPost]
        public async Task<ActionResult<Contenido>> PostContenido(Contenido contenido)
        {
            if (!ModelState.IsValid) // Verifica las validaciones
            {
                return BadRequest(ModelState);
            }
            _context.Contenidos.Add(contenido);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetContenido", new { id = contenido.Id }, contenido);
        }
        /// <summary>
        /// Actualiza un contenido existente.
        /// </summary>
        /// <param name="id">ID del contenido a actualizar.</param>
        /// <param name="contenido">Datos actualizados del contenido.</param>
        /// <response code="204">Actualización exitosa.</response>
        /// <response code="400">ID no coincide con el contenido.</response>
        /// <response code="404">Contenido no encontrado.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContenido(int id, Contenido contenido)
        {
            if (id != contenido.Id)
            {
                return BadRequest();
            }

            _context.Entry(contenido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContenidoExists(id))
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
        /// <summary>
        /// Elimina un contenido por su ID.
        /// </summary>
        /// <param name="id">ID del contenido a eliminar.</param>
        /// <response code="204">Eliminación exitosa.</response>
        /// <response code="404">Contenido no encontrado.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContenido(int id)
        {
            var contenido = await _context.Contenidos.FindAsync(id);
            if (contenido == null)
            {
                return NotFound();
            }

            _context.Contenidos.Remove(contenido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ContenidoExists(int id)
        {
            return _context.Contenidos.Any(e => e.Id == id);
        }
    }
}
