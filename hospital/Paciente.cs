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
        public bool dado_Alta { get; set; }

        public Paciente() { }
        public Paciente(string nombre, string direccion, string dni, string diagnostico, int dias_Ingresado, string pronosticoa)  
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.dni = dni;
            this.diagnostico = diagnostico;
            this.dias_Ingresado = dias_Ingresado;
        }

    }
}
