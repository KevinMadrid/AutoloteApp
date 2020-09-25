using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.Modelos
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int DetalleCarroid { get; set; }
        public DetalleCarro DetalleCarro { get; set; }

    }
}
