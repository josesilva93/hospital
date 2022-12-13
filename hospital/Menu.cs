using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hospital
{
    class Menu
    {
        public Menu(List<Paciente> pacientes, Dictionary<string, Cuerpo> listaMorge)
        {

            while (true)
            {
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("Selecciona un nivel de dificultar");
                Console.WriteLine("Introduzca \n 1) Registrar paciente \n 2) Dar de alta" +
                " \n 3) Notificar deceso \n 4) Realizar prueba \n 5) Asignar medicamento");
                Console.WriteLine("_____________________________________________");
                try
                {
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
                            DecesoPaciente(pacientes, listaMorge);
                            break;
                        case 4:
                            AsignarPrueba(pacientes);
                            break;
                        case 5:
                            AsignarMedicamento(pacientes);
                            break;
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public Paciente RegistrarPaciente()
        {
            Paciente paciente = new Paciente();
            try
            {
                Console.WriteLine("Introduzca el nombre del paciente:");              
                paciente.nombre = Console.ReadLine();
                Console.WriteLine("Introduzca el direccion del paciente:");
                paciente.direccion = Console.ReadLine();
                Console.WriteLine("Introduzca el dni del paciente:");
                paciente.dni = Console.ReadLine();
                Console.WriteLine("Introduzca los dias que estará ingresado el paciente:");
                paciente.dias_Ingresado = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Paciente registrado: ");
                MostrarDatosPaciente(paciente);               
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return paciente;
        }
        public void DarAltaPaciente(List<Paciente> pacientes)
        {
            try
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
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DecesoPaciente(List<Paciente> pacientes, Dictionary<string, Cuerpo> listaMorge)
        {
            try
            {
                bool fechaValida = false;
                Paciente paciente = new Paciente();
                Console.WriteLine("Introduzca el dni del paciente:");
                string dni = Console.ReadLine();
                string fechaFallecimiento = "";
                while (!fechaValida) 
                {
                    Console.WriteLine("Introduzca fecha del fallecimiento dd/mm/yyyy hh:mm");
                    fechaFallecimiento = Console.ReadLine();
                    fechaValida = comprobarFecha(fechaFallecimiento);
                }
                DateTime dateTimeFechaFallecimiento = DateTime.Parse(fechaFallecimiento);
                paciente = pacientes.First();
                pacientes.Remove(paciente);
                MostrarTodoslosPacientes(pacientes);
                Console.WriteLine("Paciente con dni" + dni + "eliminado.");
                Cuerpo cuerpo = new Cuerpo(Guid.NewGuid(), dni, dateTimeFechaFallecimiento);
                listaMorge.Add(dni, cuerpo);
                Console.WriteLine("Cuerpo con codigo " + cuerpo.id + "añadido a lista de morge.");
                Console.WriteLine("Hora y fecha de fallecimiento " + cuerpo.fechaFallecimiento);
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("Lista de cuerpos: ");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var m in listaMorge)
            {
                Console.WriteLine("Identificador cuerpo: " + m.Value.id);
                Console.WriteLine("DNI: " + m.Key);
            }
            Console.WriteLine("_____________________________________________");
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
            Console.WriteLine("DNI: " + paciente.dni);
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
            try
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
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void AsignarMedicamento(List<Paciente> pacientes)
        {
            try
            {
                Paciente paciente = new Paciente();
                Console.WriteLine("Introduzca el dni del paciente:");
                string dni = Console.ReadLine();
                var result = from p in pacientes where p.dni.Equals(dni) select p;
                paciente = pacientes.First();
                string medicamenteRecetado = MenuMedicamentos();
                Medicamento medicamento = new Medicamento(medicamenteRecetado);
                if (medicamenteRecetado != "")
                {
                    if (paciente.medicacion == null)
                    {
                        paciente.medicacion = new List<Medicamento>();
                        paciente.medicacion.Add(medicamento);
                    }
                    else
                    {
                        paciente.medicacion.Add(medicamento);
                    }
                    MostrarDatosPaciente(paciente);
                    Console.WriteLine("_____________________________________________");
                    Console.WriteLine("Medicamentos asignados: ");
                    foreach (var m in paciente.medicacion)
                    {
                        Console.WriteLine(m.nombre);
                    }
                    Console.WriteLine("_____________________________________________");
                }
                else
                {
                    Console.WriteLine("No se asigno ninguna prueba");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
          
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
        public bool comprobarFecha(string fecha)
        {
            Regex regex = new Regex(@"^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})(\s)([0-1][0-9]|2[0-3])(:)([0-5][0-9])$");
            //Verify whether date entered in dd/MM/yyyy format.
            bool isValid = regex.IsMatch(fecha);
            return isValid;
        }

    }
}
