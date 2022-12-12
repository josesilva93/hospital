using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    class Cuerpo
    {
        public Cuerpo(Guid id, string dni)
        {
            this.id = id;
            this.dni = dni;  
        }
        public Guid id { get; set; }
        public string dni { get; set; }
    }
}
