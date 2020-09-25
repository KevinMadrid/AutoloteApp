using Microsoft.EntityFrameworkCore;
using ProyectoIndividual_2da_Tarea_.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoIndividual_2da_Tarea_.DomainService;
namespace ProyectoIndividual_2da_Tarea_.ApplicationServices
{
    public class AutoloteAppService
    {
        private readonly AutoloteDataContext _baseDatos;
        private readonly AutoloteDomainService _autoloteDomainService;

        public AutoloteAppService(AutoloteDataContext _context,AutoloteDomainService autoloteDomainService) 
        {
            _baseDatos = _context;
            _autoloteDomainService = autoloteDomainService;

        }

        public async Task<String> GetAutoloteApplicationService(int id)
        {
            var Carro = await _baseDatos.Carros.Include(q => q.DetalleCarro).FirstOrDefaultAsync(q => q.Id == id);
           
            var respuestaDomainService = _autoloteDomainService.GetAutoloteDomainService(id,Carro);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            return null ;
        }

        public async Task<String> PostAutoloteApplicationService(Carro carro)
        {
            Autolote autolote= await LlamadaALaBaseDeDatos(carro);

            var respuestaDomainService = _autoloteDomainService.PostAutoloteDomainService(autolote);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Carros.Add(carro);
            await _baseDatos.SaveChangesAsync();

            return null;
        }

        private async Task<Autolote> LlamadaALaBaseDeDatos(Carro carro)
        {
            DetalleCarro detalleCarro=  await _baseDatos.DetalleCarros.FirstOrDefaultAsync(q => q.Id == carro.DetalleCarroid);

            var autolote = new Autolote(carro,detalleCarro);
            return autolote;

        }
        public async Task<String> PutAutoloteApplicationService(int id, Carro carro)
        {
            Autolote autolote = await LlamadaALaBaseDeDatos(carro);

            var respuestaDomainService = _autoloteDomainService.PutAutoloteDomainService(id,autolote);

            bool hayErrorEnElDomainService = respuestaDomainService != null;
            if (hayErrorEnElDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(carro).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }


        public async Task<String> DeleteAutoloteApplicationService(int id)
        {
            var carro = await _baseDatos.Carros.FindAsync(id);


            var respuestaDomainService = _autoloteDomainService.DeleteAutoloteDomainService(carro);

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
