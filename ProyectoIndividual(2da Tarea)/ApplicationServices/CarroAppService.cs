using Microsoft.EntityFrameworkCore;
using ProyectoIndividual_2da_Tarea_.DomainService;
using ProyectoIndividual_2da_Tarea_.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.ApplicationServices
{
    public class CarroAppService
    {
        private readonly AutoloteDataContext _baseDatos;
        private readonly CarroDomainService _carroDomainService;


        public CarroAppService(AutoloteDataContext _context, CarroDomainService carroDomainService)
        {
            _baseDatos = _context;
            _carroDomainService = carroDomainService;

        }
        public async Task<String> GetCarroApplicationService(int id)
        {
            var Carro = await _baseDatos.Carros.FirstOrDefaultAsync(q => q.Id == id);

            var respuestaDomainService = _carroDomainService.GetCarroDomainService(id, Carro);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }
            return null;
        }
        public async Task<String> PostCarroApplicationService(Carro carro)
        {
            Autolote autolote = await LlamadaALaBaseDeDatos(carro);

            var respuestaDomainService = _carroDomainService.PostCarroDomainService(autolote);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Carros.Add(carro);
            await _baseDatos.SaveChangesAsync();
            return null;
        }
        public async Task<String> PutCarroApplicationService(int id, Carro carro)
        {
            Autolote autolote = await LlamadaALaBaseDeDatos(carro);

            var respuestaDomainService = _carroDomainService.PutCarroDomainService(id, autolote);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(carro).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();
            return null;
        }

        private async Task<Autolote> LlamadaALaBaseDeDatos(Carro carro)
        {
            DetalleCarro detalleCarro = await _baseDatos.DetalleCarros.FirstOrDefaultAsync(q => q.Id == carro.DetalleCarroid);

            var autolote = new Autolote(carro, detalleCarro);
            return autolote;

        }

        public async Task<String> DeleteCarroApplicationService(int id)
        {
            var carro = await _baseDatos.Carros.FindAsync(id);

            var respuestaDomainService = _carroDomainService.DeleteCarroDomainService(carro);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }
            _baseDatos.Carros.Remove(carro);
            await _baseDatos.SaveChangesAsync();

            return null;
        }

    }

}
