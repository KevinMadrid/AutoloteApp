using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProyectoIndividual_2da_Tarea_.Modelos;
using ProyectoIndividual_2da_Tarea_.DataContext;
using ProyectoIndividual_2da_Tarea_.ApplicationServices;

namespace ProyectoIndividual_2da_Tarea_.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DetalleCarroController:ControllerBase
    {
        private readonly AutoloteDataContext _baseDatos;
        private readonly DetalleCarroAppService _detalleCarroAppService;

        public DetalleCarroController(AutoloteDataContext context, DetalleCarroAppService detalleCarroAppService)
        {
            _baseDatos = context;
            _detalleCarroAppService = detalleCarroAppService;

            if (_baseDatos.DetalleCarros.Count() == 0)
            {
                _baseDatos.DetalleCarros.Add(new DetalleCarro {Fecha=2020,Motor="3.5",Cilindraje="v8"});
                _baseDatos.DetalleCarros.Add(new DetalleCarro { Fecha = 2020, Motor = "3.5", Cilindraje = "v8" });
                _baseDatos.DetalleCarros.Add(new DetalleCarro { Fecha = 2019, Motor = "3.0", Cilindraje = "v6" });
                _baseDatos.DetalleCarros.Add(new DetalleCarro { Fecha = 2018, Motor = "2.5", Cilindraje = "v6" });
                _baseDatos.DetalleCarros.Add(new DetalleCarro { Fecha = 2017, Motor = "2.0", Cilindraje = "v4" });

                _baseDatos.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCarro>>> GetDetalleCarro()
        {
            return await _baseDatos.DetalleCarros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCarro>> GetDetalleCarro(int id)
        {
            var respuestaAutoloteAppService = await _detalleCarroAppService.GetDetalleCarroApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return await _baseDatos.DetalleCarros.FirstOrDefaultAsync(q => q.Id == id);
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleCarro>> PostDetalleCarro(DetalleCarro detalleCarro)
        {
            var respuestaAutoloteAppService = await _detalleCarroAppService.PostDetalleCarroApplicationService(detalleCarro);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetDetalleCarro), new { id = detalleCarro.Id }, detalleCarro);
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpPost("rango")]
        public async Task<ActionResult<DetalleCarro>> PostDetalleCarro(IEnumerable<DetalleCarro> item)
        {
            _baseDatos.DetalleCarros.AddRange(item);
            await _baseDatos.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDetalleCarro), item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCarro(int id, DetalleCarro detalleCarro)
        {
            var respuestaAutoloteAppService = await _detalleCarroAppService.PutDetalleCarroApplicationService(id,detalleCarro);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleCarro(int id,DetalleCarro detalleCarro)
        {
            var respuestaAutoloteAppService = await _detalleCarroAppService.DeleteDetalleCarroApplicationService(id,detalleCarro);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteDetalleCarro(IEnumerable<int> ids)
        {
            IEnumerable<DetalleCarro> estudiantes = _baseDatos.DetalleCarros.Where(q => ids.Contains(q.Id));
            if (estudiantes == null)
            {
                return NotFound();
            }
            _baseDatos.DetalleCarros.RemoveRange(estudiantes);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }
    }
}
