namespace GestionCadeteria;
internal class Program
{
    private static void Main(string[] args)
    {
        string DatosCadeteriaCSV = "cadeteria.csv";
        string DatosCadetesCSV = "cadetes.csv";
        string DatosCadeteriaJSON = "cadeteria.json";
        string DatosCadetesJSON = "cadetes.json";
        Cadeteria cadeteria = null;

        string inputMenu, inputArchivo;
        int opcionMenu, opcionArchivo;
        bool gestionPedidos = false, cargadoDeDatos = true;

        while (cargadoDeDatos)
        {

            do
            {
                Console.WriteLine("Cargar datos Cadeteria con:\n-1: archivo CSV\n-2:archivo JSON");
                inputArchivo = Console.ReadLine();
            } while (string.IsNullOrEmpty(inputArchivo));

            if (int.TryParse(inputArchivo, out opcionArchivo) && 1 <= opcionArchivo && opcionArchivo <= 2)
            {
                switch (opcionArchivo)
                {
                    case 1:
                        AccesoADatos AccesoADatos1 = new AccesoCSV();
                        cadeteria = AccesoADatos1.CrearCadeteria(DatosCadeteriaCSV);
                        cadeteria.Cadetes = AccesoADatos1.CargarCadetes(DatosCadetesCSV);
                        cargadoDeDatos = false;
                        gestionPedidos = true;
                        break;
                    case 2:
                        AccesoADatos accesoADatos2 = new AccesoJSON();
                        cadeteria = accesoADatos2.CrearCadeteria(DatosCadeteriaJSON);
                        cadeteria.Cadetes = accesoADatos2.CargarCadetes(DatosCadetesJSON);
                        cargadoDeDatos = false;
                        gestionPedidos = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("--- Ingrese un opción válida ---");
            }
        }


        while (gestionPedidos)
        {
            Console.WriteLine("***** Gestión de pedidos *****");
            Console.WriteLine("1:Dar de alta un pedido");
            Console.WriteLine("2:Asignar cadete a pedido");
            Console.WriteLine("3:Cambiar estado del pedido");
            Console.WriteLine("4:Reasignar Cadete a pedido");
            Console.WriteLine("5:Eliminar pedido");
            Console.WriteLine("6:Finalizar gestion");
            Console.WriteLine();

            do
            {
                Console.WriteLine("Ingrese una opcion:");
                inputMenu = Console.ReadLine();
            } while (string.IsNullOrEmpty(inputMenu));

            bool resultado = int.TryParse(inputMenu, out opcionMenu);

            if (resultado && 1 <= opcionMenu && opcionMenu <= 6)
            {
                switch (opcionMenu)
                {
                    case 1:
                        int nroPedido;
                        string observacionPedido;
                        string nombreCliente, direccionCliente, datosReferenciaDireccion;
                        long telefonoCliente;

                        Console.WriteLine("Ingrese los siguientes datos del pedido:");
                        Console.WriteLine("-Nro pedido:");
                        string inputNroPedido = Console.ReadLine();
                        Console.WriteLine("-Observación Pedido:");
                        observacionPedido = Console.ReadLine();
                        Console.WriteLine("-Nombre Cliente:");
                        nombreCliente = Console.ReadLine();
                        Console.WriteLine("-Dirección Cliente:");
                        direccionCliente = Console.ReadLine();
                        Console.WriteLine("-Telefono Cliente");
                        string inputNroTel = Console.ReadLine();
                        Console.WriteLine("-Datos de referencia:");
                        datosReferenciaDireccion = Console.ReadLine();

                        bool resultadoNroPedido = int.TryParse(inputNroPedido, out nroPedido);
                        bool resultadoTel = long.TryParse(inputNroTel, out telefonoCliente);

                        if (resultadoNroPedido && resultadoTel)
                        {
                            cadeteria.DarDeAltaPedidio(nroPedido, observacionPedido, nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccion);
                            Console.WriteLine("Pedido ingresado con exito!\n");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo recibir pedido");
                        }
                        break;
                    case 2:
                        int idCadete;
                        string inputIdCadete;
                        bool resultadoIdCadete;
                        if (cadeteria.Pedidos.Count() > 0)
                        {
                            Console.WriteLine("Ingrese el ID del cadete:");
                            inputIdCadete = Console.ReadLine();

                            Console.WriteLine("Ingrese el Nro del pedido:");
                            inputNroPedido = Console.ReadLine();

                            resultadoIdCadete = int.TryParse(inputIdCadete, out idCadete);
                            resultadoNroPedido = int.TryParse(inputNroPedido, out nroPedido);

                            if (resultadoNroPedido && resultadoIdCadete)
                            {
                                if (cadeteria.AsignarCadeteAPedido(idCadete, nroPedido))
                                {
                                    Console.WriteLine("Cadete asignado con exito!");
                                }
                                else
                                {
                                    Console.WriteLine("No se encontro pedido");
                                }
                            }
                            else
                            {
                                if (resultadoNroPedido)
                                {
                                    Console.WriteLine("----- Ingrese un nro de pedido valido-----");
                                }
                                else
                                {
                                    Console.WriteLine("----- Ingrese un Id de cadete valido -----");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("No hay pedidios ingresados");
                        }
                        break;
                    case 3:
                        int numeroEstado;

                        Console.WriteLine("Ingrese el Nro del pedido:");
                        inputNroPedido = Console.ReadLine();

                        Console.WriteLine("Seleccione el nuevo estado:\n1-Entregado\n2-En Camino\n3-Cancelado");
                        string inputNumeroEstado = Console.ReadLine();

                        resultadoNroPedido = int.TryParse(inputNroPedido, out nroPedido);
                        bool resultadoNumeroEstado = int.TryParse(inputNumeroEstado, out numeroEstado);

                        if (resultadoNroPedido && resultadoNumeroEstado && 1 <= numeroEstado && numeroEstado <= 3)
                        {
                            EstadoPedido nuevoEstado = (EstadoPedido)numeroEstado;
                            if (cadeteria.CambiarEstadoPedido(nroPedido, nuevoEstado))
                            {
                                Console.WriteLine("Estado del pedido cambiado con exito!");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró pedidio");
                            }
                        }
                        else
                        {
                            if (resultadoNroPedido)
                            {
                                Console.WriteLine("----- Ingrese un nro de pedido válido-----");
                            }
                            else
                            {
                                Console.WriteLine("----- Ingrese un ESTADO de pedido válido-----");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el Nro del pedido:");
                        inputNroPedido = Console.ReadLine();
                        Console.WriteLine("Ingrese el ID del nuevo cadete:");
                        inputIdCadete = Console.ReadLine();

                        resultadoNroPedido = int.TryParse(inputNroPedido, out nroPedido);
                        resultadoIdCadete = int.TryParse(inputIdCadete, out idCadete);

                        if (resultadoIdCadete && resultadoNroPedido)
                        {
                            if (cadeteria.ReasignarCadeteAPedido(idCadete, nroPedido))
                            {
                                Console.WriteLine("Nuevo cadete asignado con exito!");
                            }
                            else
                            {
                                Console.WriteLine("No se encontro pedido o no se encontro cadete");
                            }
                        }
                        else
                        {
                            if (resultadoNroPedido)
                            {
                                Console.WriteLine("----- Ingrese un nro de pedido válido -----");
                            }
                            else
                            {
                                Console.WriteLine("----- Ingrese un ID de cadete válido -----");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Ingrese el Nro del pedido:");
                        inputNroPedido = Console.ReadLine();
                        resultadoNroPedido = int.TryParse(inputNroPedido, out nroPedido);
                        if (resultadoNroPedido)
                        {
                            if (cadeteria.EliminarPedido(nroPedido))
                            {
                                Console.WriteLine("Pedido eliminado con éxito!");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró pedido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("----- Ingrese un nro de pedido válido -----");
                        }
                        break;
                    case 6:
                        gestionPedidos = false;
                        Console.WriteLine("*** Fin de Gestión ***");
                        Console.WriteLine();
                        break;
                }
                
            }else
            {
                Console.WriteLine("\n Ingrese una opción válida\n");
            }
        }

        //Informes.InformeFinalJornada(cadeteria);
    }
}





