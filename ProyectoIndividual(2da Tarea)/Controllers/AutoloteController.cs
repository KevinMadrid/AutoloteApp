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
    public class AutoloteController:ControllerBase
    {
        private readonly AutoloteDataContext _baseDatos;
        private readonly AutoloteAppService _autoloteAppService;

        public AutoloteController(AutoloteDataContext context, AutoloteAppService autoloteAppService)
        {
            _baseDatos = context;
            _autoloteAppService = autoloteAppService;

            if (_baseDatos.Carros.Count() == 0)
            {
                _baseDatos.Carros.Add(new Carro { Marca = "Toyora", Modelo= "Land-Cruiser",Color="Rojo vino",DetalleCarroid=1 });
                _baseDatos.Carros.Add(new Carro { Marca = "Nissan", Modelo = "NP-300",Color="Azul", DetalleCarroid = 2 });
                _baseDatos.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetAutolote()
        {
            return await _baseDatos.Carros.Include(q => q.DetalleCarro).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetAutolote(int id)
        {
            var respuestaAutoloteAppService = await _autoloteAppService.GetAutoloteApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return await _baseDatos.Carros.FirstOrDefaultAsync(q => q.Id == id);
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Carro>> PostAutolote(Carro carro)
        {
            var respuestaAutoloteAppService = await _autoloteAppService.PostAutoloteApplicationService(carro);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return CreatedAtAction(nameof(GetAutolote), new { id = carro.Id }, carro);
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpPost("rango")]

        public async Task<ActionResult<Carro>> PostAutolote(IEnumerable<Carro> item)
        {
            _baseDatos.Carros.AddRange(item);
            await _baseDatos.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAutolote), item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutolote(int id, Carro carro)
        {
            var respuestaAutoloteAppService = await _autoloteAppService.PutAutoloteApplicationService(id,carro);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutolote(int id)
        {
            var respuestaAutoloteAppService = await _autoloteAppService.DeleteAutoloteApplicationService(id);

            bool noHayErroresEnLasValidaciones = respuestaAutoloteAppService == null;
            if (noHayErroresEnLasValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAutoloteAppService);
        }

        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteAutolote(IEnumerable<int> ids)
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
