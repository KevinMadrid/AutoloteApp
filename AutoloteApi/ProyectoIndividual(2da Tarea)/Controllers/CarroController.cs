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
    public class CarroController:ControllerBase
    {
        private readonly AutoloteDataContext _baseDatos;
        private readonly CarroAppService _carroAppService;


        public CarroController(AutoloteDataContext context, CarroAppService carroAppService)
        {
            _baseDatos = context;
            _carroAppService = carroAppService;

            if (_baseDatos.Carros.Count() == 0)
            {
                _baseDatos.Carros.Add(new Carro { Marca = "Toyora", Modelo = "Land-Cruiser", Color = "Rojo vino", DetalleCarroid = 1 });
                _baseDatos.Carros.Add(new Carro { Marca = "Nissan", Modelo = "NP-300", Color = "Azul", DetalleCarroid = 2 });
                _baseDatos.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarro()
        {
            return await _baseDatos.Carros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(int id)
        {
            var respuestaAutoloteAppService = await _carroAppService.GetCarroApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return await _baseDatos.Carros.FirstOrDefaultAsync(q => q.Id == id);
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
            var respuestaAutoloteAppService = await _carroAppService.PostCarroApplicationService(carro);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetCarro), new { id = carro.Id }, carro);
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpPost("rango")]
        public async Task<ActionResult<Carro>> PostCarro(IEnumerable<Carro> item)
        {
          
            _baseDatos.Carros.AddRange(item);
            await _baseDatos.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCarro), item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, Carro carro)
        {
            var respuestaAutoloteAppService = await _carroAppService.PutCarroApplicationService(id,carro);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            var respuestaAutoloteAppService = await _carroAppService.DeleteCarroApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteCarro(IEnumerable<int> ids)
        {
            IEnumerable<Carro> estudiantes = _baseDatos.Carros.Where(q => ids.Contains(q.Id));
            if (estudiantes == null)
            {
                return NotFound();
            }
            _baseDatos.Carros.RemoveRange(estudiantes);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }
    }
}

