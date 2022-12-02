using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    class Menu
    {
        public Menu(List<Paciente> pacientes)
        {

            while (true)
            {
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("Selecciona un nivel de dificultar");
                Console.WriteLine("Introduzca \n 1) Registrar paciente \n 2) Dar de alta" +
                " \n 3) Notificar deceso \n 4) Realizar prueba \n 5) Asignar medicamento");
                Console.WriteLine("_____________________________________________");
                int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
                switch (opcionSeleccionada)
                {
                    case 1:
                        pacientes.Add(RegistrarPaciente());
                        break;
                    case 2:
                        DarAltaPaciente(pacientes);
                        break;
                    case 3:
                        DecesoPaciente(pacientes);
                        break;
                    case 4:
                        AsignarPrueba(pacientes);
                        break;
                    case 5:
                        AsignarMedicamento(pacientes);
                        break;
                }

            }
        }
        public Paciente RegistrarPaciente()
        {
            Console.WriteLine("Introduzca el nombre del paciente:");
            Paciente paciente = new Paciente();
            paciente.nombre = Console.ReadLine();
            Console.WriteLine("Introduzca el direccion del paciente:");
            paciente.direccion = Console.ReadLine();
            Console.WriteLine("Introduzca el dni del paciente:");
            paciente.dni = Console.ReadLine();
            Console.WriteLine("Introduzca los dias que estará ingresado el paciente:");
            paciente.dias_Ingresado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Paciente registrado: ");
            MostrarDatosPaciente(paciente);
            return paciente;
        }
        public void DarAltaPaciente(List<Paciente> pacientes)
        {
            Paciente paciente = new Paciente();
            Console.WriteLine("Introduzca el dni del paciente:");
            string dni = Console.ReadLine();
            var result = from p in pacientes where p.dni.Equals(dni) select p;
            paciente = pacientes.First();
            paciente.dado_Alta = true;
            Console.WriteLine("Introduzca la nota especifica de alta: ");
            string nota_alta = Console.ReadLine();
            Console.WriteLine("Paciente dado de alta: ");
            Console.WriteLine("Nota especifica de alta: " + nota_alta);
            MostrarDatosPaciente(paciente);
        }
        public void DecesoPaciente(List<Paciente> pacientes)
        {
            Paciente paciente = new Paciente();
            Console.WriteLine("Introduzca el dni del paciente:");
            string dni = Console.ReadLine();

            paciente = pacientes.First();
            pacientes.Remove(paciente);
            MostrarTodoslosPacientes(pacientes);
            Console.WriteLine("Paciente con dni" + dni + "eliminado.");
        }
        public void MostrarDatosPaciente(Paciente paciente)
        {
            string alta;
            if (!paciente.dado_Alta)
            {
                alta = "No";
            }
            else alta = "Si";
            Console.WriteLine("Nombre: " + paciente.nombre);
            Console.WriteLine("Direccion: " + paciente.direccion);
            Console.WriteLine("Tiempo de ingreso " + paciente.dias_Ingresado);
            Console.WriteLine("Tiene alta medica " + alta);
        }
        public void MostrarTodoslosPacientes(List<Paciente> pacientes)
        {
            foreach (Paciente paciente in pacientes)
            {
                MostrarDatosPaciente(paciente);
            }

        }

        public void AsignarPrueba(List<Paciente> pacientes)
        {
            Paciente paciente = new Paciente();
            Console.WriteLine("Introduzca el dni del paciente:");
            string dni = Console.ReadLine();
            var result = from p in pacientes where p.dni.Equals(dni) select p;
            paciente = pacientes.First();
            string pruebaSeleccionada = MenuPruebas();
            if (pruebaSeleccionada != "")
            {

                if (paciente.pruebas == null)
                {
                    paciente.pruebas = new List<string>();
                }
                else
                {
                    paciente.pruebas.Add(pruebaSeleccionada);
                }

                Console.WriteLine("Se asigno una prueba de: " + pruebaSeleccionada);
            }
            else
            {
                Console.WriteLine("No se asigno ninguna prueba");
            }
            MostrarDatosPaciente(paciente);
        }
        public void AsignarMedicamento(List<Paciente> pacientes)
        {
            Paciente paciente = new Paciente();
            Console.WriteLine("Introduzca el dni del paciente:");
            string dni = Console.ReadLine();
            var result = from p in pacientes where p.dni.Equals(dni) select p;
            paciente = pacientes.First();
            string medicamenteRecetado = MenuPruebas();
            if (medicamenteRecetado != "")
            {
                if (paciente.medicacion == null)
                {
                    paciente.medicacion = new List<string>();
                }
                else
                {
                    paciente.pruebas.Add(medicamenteRecetado);
                }

                Console.WriteLine("Se receto: " + medicamenteRecetado);
            }
            else
            {
                Console.WriteLine("No se asigno ninguna prueba");
            }
            MostrarDatosPaciente(paciente);
        }
        public string MenuPruebas()
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("Selecciona un nivel de dificultar");
            Console.WriteLine("Introduzca \n 1) Rayos X \n 2) TAC" +
            " \n 3) Medida azucar \n 4) Prueba de esfuerzo \n 5) Escanner \n Pulse otro numero para salir");
            Console.WriteLine("_____________________________________________");
            int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
            switch (opcionSeleccionada)
            {
                case 1:
                    return "Rayos X";
                case 2:
                    return "TAC";
                case 3:
                    return "Medida azucar";
                case 4:
                    return "Prueba de esfuerzo";
                case 5:
                    return "Escanner";
                default:
                    return "";
            }
        }
        public string MenuMedicamentos()
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("Selecciona un nivel de dificultar");
            Console.WriteLine("Introduzca \n 1) Aspirina \n 2) Rizinotizol" +
            " \n 3) Cascahueton \n 4) Filecodeina \n 5) Surnoteina \n Pulse otro numero para salir");
            Console.WriteLine("_____________________________________________");
            int opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
            switch (opcionSeleccionada)
            {
                case 1:
                    return "Aspirina";
                case 2:
                    return "Rizinotizol";
                case 3:
                    return "Cascahueton";
                case 4:
                    return "Filecodeina";
                case 5:
                    return "Surnoteina";
                default:
                    return "";
            }
        }
    }
}
