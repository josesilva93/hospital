using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hospital
{
    class Manager
    {
        public Manager()
        {
            List<Paciente> pacientes= new List<Paciente>();

            Dictionary<string, Cuerpo> morgeList = new Dictionary<string, Cuerpo>();
            AñadirPacientesToList(pacientes);
            Menu menu= new Menu(pacientes, morgeList);

        }
        public void AñadirPacientesToList(List<Paciente> pacientes)
        {
            Paciente paciente1 = new Paciente("Pepe", "dasfdsfsdf", "1","", 30);
            Paciente paciente2 = new Paciente("Manolo", "dasfdsfsdf", "2","",  30);
            Paciente paciente3 = new Paciente("Alejandro", "dasfdsfsdf", "3", "", 30);
            Paciente paciente4 = new Paciente("Manuel", "dasfdsfsdf", "4", "", 30);
            pacientes.Add(paciente1);
            pacientes.Add(paciente2);
            pacientes.Add(paciente3);
            pacientes.Add(paciente4);
        }

        }
}
