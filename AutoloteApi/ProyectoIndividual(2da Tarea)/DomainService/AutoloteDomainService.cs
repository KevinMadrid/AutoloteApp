using ProyectoIndividual_2da_Tarea_.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.DomainService
{
    public class AutoloteDomainService
    {
        public string GetAutoloteDomainService(int id, Carro carro)
        {
            if (carro== null)
            {
                return "El Carro no Existe";
            }
            return null;
        }
        public string PostAutoloteDomainService(Autolote autolote)
        {   
            
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
        public string PutAutoloteDomainService(int id,Autolote autolote)
        {
            if (id != autolote.Carro.Id)
            {
                return "No existe el Dato";
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
        public string DeleteAutoloteDomainService(Carro carro)
        {
            if (carro== null)
            {
                return "No se Encuentra el Carro";
            }
            return null;
        }

    }

 
}
