using ProyectoIndividual_2da_Tarea_.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.DomainService
{
    public class DetalleCarroDomainService
    {
        public string GetDetalleCarroDomainService(DetalleCarro detalleCarro)
        {
            if (detalleCarro == null)
            {
                return "No existe el Detalle del Carro";
            }
            return null;
        }
        public string PostDetalleCarroDomainService(DetalleCarro detalleCarro)
        {
            return null;
        }
        public string PutDetalleCarroDomainService(int id,DetalleCarro detalleCarro)
        {
            if (id != detalleCarro.Id)
            {
                return "El Detalle del Carro no Existe";
            }
            return null;
        }
        public string DeleteDetalleCarroDomainService(DetalleCarro detalleCarro)
        {
            if (detalleCarro == null)
            {
                return "El Detalle del Carro no existe";
            }
            
            return null;
        }
    }
}
