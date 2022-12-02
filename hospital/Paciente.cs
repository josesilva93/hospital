using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    class Paciente : Persona
    {
        public string diagnostico { get; set; }
        public int dias_Ingresado { get; set; }
        public string pronostico { get; set; }
        public List<string> medicacion { get; set; }
        public List<string> pruebas { get; set; }

        public Paciente(string diagnostico, int dias_Ingresado, string pronostico, List<string>medicacion, List<string> pruebas)  
        {
            this.diagnostico = diagnostico;
            this.dias_Ingresado = dias_Ingresado;
            this.pronostico = pronostico;
            this.medicacion = medicacion;
            this.pruebas = pruebas;
        }

    }
}
