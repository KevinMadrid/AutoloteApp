using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.Modelos
{
    public class DetalleCarro
    {
        public int Id { get; set; }
        public int Fecha { get; set; }
        public string Motor { get; set; }
        public string Cilindraje { get; set; }
        public List<Carro> Carros { get; set; }

    }
}
