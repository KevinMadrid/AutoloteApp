using ProyectoIndividual_2da_Tarea_.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.DomainService
{
    public class CarroDomainService
    {
        public string GetCarroDomainService(int id, Carro carro)
        {
            if (carro == null)
            {
                return "El Carro No Existe";
            }
            return null;
        }
        public string PostCarroDomainService(Autolote autolote)
        {

            if (autolote.DetalleCarro== null)
            {
                return "El Detalle del Carro no existe";
            }
            if (autolote.DetalleCarro.Fecha <= 2008)
            {
                return "El Año del carro debe ser mayor de 2008 para ser ingresado";
            }
            return null;
        }
        public string PutCarroDomainService(int id,Autolote autolote)
        {
            if (id != autolote.Carro.Id)
            {
                return "El Detalle del Carro no existe";
            }

            if (autolote.DetalleCarro == null)
            {
                return "El Detalle del Carro no existe";
            }
            if (autolote.DetalleCarro.Fecha <= 2008)
            {
                return "El Año del carro debe ser mayor de 2008 para ser ingresado";
            }
            return null;
        }
        public string DeleteCarroDomainService(Carro carro)
        {
            if (carro == null)
            {
                return "No Existe el Carro";
            }

            return null;
        }
    }
}
