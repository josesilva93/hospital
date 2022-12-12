using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    class Medicamento
    {
        public Medicamento(string nombre) 
        {
            this.nombre = nombre;
            this.precio = 0;
            this.indicaciones = "";
            this.efectosSecundarios = "";
            this.efectosAdversos = "";

        }
        public string nombre { get; set; }
        public string indicaciones { get; set; }    
        public string efectosSecundarios { get; set;}
        public string efectosAdversos { get; set;}
        public double precio { get; set; }
    }
}
