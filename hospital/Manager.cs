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
            Menu menu= new Menu(pacientes);

        }
      
    }
}
