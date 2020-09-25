using Microsoft.EntityFrameworkCore;
using ProyectoIndividual_2da_Tarea_.DomainService;
using ProyectoIndividual_2da_Tarea_.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.ApplicationServices
{
    public class DetalleCarroAppService
    {
        private readonly AutoloteDataContext _baseDatos;
        private readonly DetalleCarroDomainService _detalleCarroDomainService;

        public DetalleCarroAppService(AutoloteDataContext _context, DetalleCarroDomainService detalleCarroDomainService)
        {
            _baseDatos = _context;
            _detalleCarroDomainService = detalleCarroDomainService;

        }
        public async Task<String> GetDetalleCarroApplicationService(int id)
        {
            var DetalleCarro = await _baseDatos.DetalleCarros.FirstOrDefaultAsync(q => q.Id == id);

            var respuestaDomainService = _detalleCarroDomainService.GetDetalleCarroDomainService(DetalleCarro);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<String> PostDetalleCarroApplicationService(DetalleCarro detalleCarro)
        {
            var respuestaDomainService = _detalleCarroDomainService.PostDetalleCarroDomainService(detalleCarro);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.DetalleCarros.Add(detalleCarro);
            await _baseDatos.SaveChangesAsync();
            return null;
        }
        public async Task<String> PutDetalleCarroApplicationService(int id, DetalleCarro detalleCarro)
        {
            var respuestaDomainService = _detalleCarroDomainService.PutDetalleCarroDomainService(id,detalleCarro);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(detalleCarro).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();
            return null;
        }
        public async Task<String> DeleteDetalleCarroApplicationService(int id,DetalleCarro detalleCarro)
        {
            var DetalleCarro = await _baseDatos.DetalleCarros.FindAsync(id);

            var respuestaDomainService = _detalleCarroDomainService.DeleteDetalleCarroDomainService(detalleCarro);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.DetalleCarros.Remove(DetalleCarro);
            await _baseDatos.SaveChangesAsync();

            return null;
        }


    }
}
