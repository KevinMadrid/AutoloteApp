using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIndividual_2da_Tarea_.Modelos
{
    public class Autolote
    {

        public Autolote(Carro carro, DetalleCarro detalleCarro)
        {
            Carro = carro;
            DetalleCarro = detalleCarro;
        }

        public Carro Carro{ get; set; }
        public DetalleCarro DetalleCarro{ get; set; }
    }
}
