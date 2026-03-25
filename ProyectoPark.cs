using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{

    // Variables para almacenar la informacion del parqueo
    static int ticketsCreados = 0;
    static int ticketsCerrados = 0;
    static int tipoVehículo = 0;
    static int espaciosOcupados = 0;
    static int tiempoSimulado = 0;
    static int minutosSimulados = 0;
    static int minutoEntrada = 0;
    static int minutosEstacionados = 1;
    static int capacidadParqueo = 0;
    static int opcionMenu = 0;
    static int horasCobradas = 0;
    static int minutosCobrados = 0;
    static int multa = 0;
    static bool esVIP = false;
    static bool ticketActivo = false;
    static double dineroRecaudado = 0;
    static double tarifa = 0;
    static double montoFinal = 0.0;
    static string placa = " ";
    static string nombreOperador = " ";
    static string codigoTurno = " ";
    static string nombreCliente;
    static bool bandera = true;
    static string entrada = " ";


    static void Main()
    {

        Console.ForegroundColor = ConsoleColor.DarkYellow; // color informativo
        Console.WriteLine("Ingrese nombre del Operador: ");

        nombreOperador = Console.ReadLine();


        // Ciclo para validar que el codigo de turno tenga una longitud exacta de 4 caracteres

        while (true)
        {
            Console.WriteLine("Ingrese el codigo de turno ( longitud 4 caracteres) ");
            entrada = Console.ReadLine();



            if (entrada.Length != 4)
            {
                Console.WriteLine("Vuelva a ingresar el codigo de turno unicamente con 4 caracteres ");
                continue;
            }

            codigoTurno = entrada.Trim();

            break;
        }


        // Ciclo para validar que la capacidad del parqueo es <= 10
        // Ademas se validar que lo ingresado sea un numero
        while (true)
        {
            Console.WriteLine("Ingrese la capacidad del parqueo (minimo 10): ");
            entrada = Console.ReadLine();

            // Validando que lo ingresado sea un numero
            if (int.TryParse(entrada, out int numero) == false)
            {
                Console.WriteLine("Valor ingresado no valido.");
                continue;
            }

            capacidadParqueo = int.Parse(entrada);

            // Validando que la capacidad del parqueo sea minimo 10
            if (capacidadParqueo < 10)
            {
                Console.WriteLine("El valor ingresado debe ser minimo  10.");
                continue;
            }

            break;
        }

        Console.ResetColor();  // color informativo

        //Implementando el menu del sistema
        // Este validara si lo que el usauario ingreso es una opcion valida

        do
        {
            // Mostrando el menu de opciones
            Console.ForegroundColor = ConsoleColor.Green; // color del menú

            Console.WriteLine("\n Bienvenidos al parqueo");
            Console.WriteLine("\n Seleccione una de las siguientes opciones:");
            Console.WriteLine("1. Crear ticket de entrada");
            Console.WriteLine("2. Registrar salida y calcular cobro");
            Console.WriteLine("3. Ver estado del parqueo");
            Console.WriteLine("4. Simular paso del tiempo");
            Console.WriteLine("5. Salir");

            Console.ResetColor();  // color del menú


            entrada = Console.ReadLine();

            // Validando que lo ingresado sea un numero
            if (int.TryParse(entrada, out int numero) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red; // color de error
                Console.WriteLine("Valor ingresado no valido.");
                Console.ResetColor();

                continue;
            }

            opcionMenu = int.Parse(entrada);

            // Validando que la opcion ingresada sea entre 1 y 5
            switch (opcionMenu)
            {
                case 1:
                    Console.WriteLine("Creando ticket...");

                    // Validando que el parqueo no este lleno antes de crear un nuevo ticket de entrada
                    if (espaciosOcupados >= capacidadParqueo || ticketActivo == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // color de error

                        Console.WriteLine("El parqueo esta lleno o existe un ticket activo. Por el momento no se pueden crear mas tickets de entrada.");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine("Ingrese el nombre del cliente: ");
                        nombreCliente = Console.ReadLine();
                        Console.ResetColor();

                        // Validando que el nombre del cliente no tenga espacios

                        while (nombreCliente.Contains(" ") == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // color de error

                            Console.WriteLine("El nombre del cliente no debe contener espacios. Por favor, ingrese un nombre válido:");
                            nombreCliente = Console.ReadLine();
                            Console.ResetColor();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow; // color de error

                        Console.WriteLine("Ingrese la placa del vehículo: ");
                        placa = Console.ReadLine();
                        Console.ResetColor();

                        // Validando que la placa del vehículo no tenga espacios
                        while (placa.Contains(" ") == true || placa.Length < 6 || placa.Length > 8)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // color de error

                            Console.WriteLine("La placa del vehículo no debe contener espacios y la longitud debe de ser de 6 a 8 caracteres. Por favor, ingrese una placa válida:");
                            placa = Console.ReadLine();
                            Console.ResetColor();
                        }

                        // Ciclo para validar que el tipo de vehículo sea entre 1 y 3
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; // color submenu 

                            Console.WriteLine("Seleccione el tipo de vehículo:");
                            Console.WriteLine("1. Automóvil");
                            Console.WriteLine("2. Motocicleta");
                            Console.WriteLine("3. PickUp");

                            entrada = Console.ReadLine();
                            Console.ResetColor();


                            // Validando que lo ingresado sea un numero
                            if (int.TryParse(entrada, out int numero2) == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red; // color de error

                                Console.WriteLine("Valor ingresado no valido.");
                                Console.ResetColor();
                                continue;
                            }

                            tipoVehículo = int.Parse(entrada);
                            // Validando que el tipo de vehículo sea entre 1 y 3
                            if (tipoVehículo < 1 || tipoVehículo > 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red; // color de error

                                Console.WriteLine("Tipo de vehículo no válido.");
                                Console.ResetColor();
                                continue;
                            }

                            break;

                        }

                        // Creando el ticket de entrada
                        ticketsCreados++;
                        espaciosOcupados++;
                        ticketActivo = true;
                        minutoEntrada = tiempoSimulado;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine($"Ticket creado exitosamente para {nombreCliente} con placa {placa}.");
                        Console.ResetColor();


                    }

                    break;

                case 2:
                    Console.WriteLine("Registrando salida...");
                    multa = 0;
                    if (ticketActivo == true)
                    {
                        minutosEstacionados = tiempoSimulado - minutoEntrada;
                        horasCobradas = minutosEstacionados / 60;
                        minutosCobrados = minutosEstacionados % 60;
                        if (minutosCobrados > 15 && horasCobradas == 0)
                        {
                            horasCobradas = 1;
                        }
                        if (minutosEstacionados <= 15 && horasCobradas == 0)
                        {
                            montoFinal = 0;
                        }
                        else
                        {
                            if (horasCobradas > 6)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Advertencia, multa proxima");
                                Console.ResetColor();
                                multa = 25;
                            }
                            if (tipoVehículo == 1)
                            {
                                tarifa = 5 * horasCobradas;

                            }
                            else if (tipoVehículo == 2)
                            {
                                tarifa = 10 * horasCobradas;

                            }
                            else if (tipoVehículo == 3)
                            {
                                tarifa = 15 * horasCobradas;
                            }
                            while (true)
                            {
                                Console.WriteLine("Es cliente vip? Si/No");
                                string vip = Console.ReadLine();
                                if (vip != "Si" && vip != "No")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ingrese Si/No");
                                    Console.ResetColor();
                                    continue;
                                }
                                if (vip == "Si")
                                {
                                    esVIP = true;
                                }
                                else
                                {
                                    esVIP = false;
                                }
                                break;
                            }
                            if (esVIP)
                            {
                                montoFinal = tarifa - (tarifa * 0.10) + multa;
                            }
                            else
                            {
                                montoFinal = tarifa + multa;
                            }
                            if (minutosEstacionados > 720)
                            {
                                montoFinal = montoFinal + (montoFinal * 0.20);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Se aplico recargo por permanencia prolongada");
                                Console.ResetColor();
                            }
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // color de error

                        Console.WriteLine("No hay ticket activo");
                        Console.ResetColor();
                        break;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Su monto final es: {montoFinal}");
                    Console.ResetColor();
                    dineroRecaudado += montoFinal;
                    ticketsCerrados++;
                    ticketActivo = false;
                    espaciosOcupados--;
                    break;

                case 3:
                    Console.WriteLine("Mostrando estado del parqueo...");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Capacidad del parqueo: {capacidadParqueo}");
                    Console.WriteLine($"Espacios ocupados: {espaciosOcupados}");
                    Console.WriteLine($"Espacios disponibles: {capacidadParqueo - espaciosOcupados}");
                    Console.WriteLine($"Tickets creados: {ticketsCreados}");
                    Console.WriteLine($"Tickets cerrados: {ticketsCerrados}");
                    Console.WriteLine($"Dinero recaudado: ${dineroRecaudado}");
                    Console.WriteLine($"Tiempo simulado: {tiempoSimulado} minutos");
                    Console.ResetColor();


                    break;

                case 4:
                    Console.WriteLine("Simulando el paso del tiempo ...");


                    // Ciclo para validar que la cantidad de minutos a simular sea entre 1 y 1440 (24 horas)
                    while (true)
                    {
                        // Solicitando al usuario la cantidad de minutos a simular

                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine("Ingrese la cantidad de minutos a simular: ");
                        entrada = Console.ReadLine();
                        Console.ResetColor();

                        // Validando que lo ingresado sea un numero
                        if (int.TryParse(entrada, out int numero3) == false)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                            Console.WriteLine("Valor ingresado no valido.");
                            Console.ResetColor();
                            continue;
                        }

                        minutosSimulados = int.Parse(entrada);

                        // Validando que la cantidad de minutos a simular sea entre 1 y 1440
                        if (minutosSimulados < 1 || minutosSimulados > 1440)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // color de error

                            Console.WriteLine("La cantidad de minutos a simular debe estar en el rango de 1 a 1440 .");
                            Console.ResetColor();
                            continue;
                        }

                        // Actualizando el tiempo simulado
                        tiempoSimulado = tiempoSimulado + minutosSimulados;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        Console.WriteLine($"Tiempo simulado actualizado. Tiempo total simulado: {tiempoSimulado} minutos.");
                        Console.ResetColor();

                        if (ticketActivo == true)
                        {

                            minutosEstacionados = tiempoSimulado - minutoEntrada;

                            Console.ForegroundColor = ConsoleColor.DarkYellow;

                            Console.WriteLine($"El vehículo con placa {placa} ha estado estacionado por {minutosEstacionados} minutos.");
                            Console.ResetColor();
                            // Validando si el tiempo estacionado supera las 6 horas (360 minutos) o las 12 horas (720 minutos) para mostrar las advertencias correspondientes
                            if (minutosEstacionados > 720)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Advertencia, existira recargo por permanencia extrema.");
                                Console.ResetColor();
                            }
                            else if (minutosEstacionados > 360)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Advertencia, multa proxima");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // color de error

                            Console.WriteLine("No hay un ticket activo para calcular el tiempo estacionado.");
                            Console.ResetColor();
                        }


                        break;
                    }

                    break;

                case 5://Reporte final
                    Console.WriteLine("Saliendo del sistema...");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Resumen Final del turno");
                    Console.WriteLine("Operador del turno: " + nombreOperador);
                    Console.WriteLine("Codigo de turno: " + codigoTurno);
                    Console.WriteLine("Disponibilidad del parqueo: " + (capacidadParqueo - espaciosOcupados));
                    Console.WriteLine("Total recaudado: " + dineroRecaudado);
                    Console.WriteLine("Los tickets cerrados son: " + ticketsCerrados + " Los tickets creados son: " + ticketsCreados);
                    bandera = false;
                    Console.ResetColor();
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (bandera);






    }

}

