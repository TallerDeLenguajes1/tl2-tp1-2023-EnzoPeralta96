using GestionPedidos;

public class HelperDeArchivo
{
    private List<Pedido> pedidosIngresados;

    public HelperDeArchivo()
    {
        pedidosIngresados = new List<Pedido>();
    }

    public List<Pedido> PedidosIngresados { get => pedidosIngresados; set => pedidosIngresados = value; }

    public  void DarDeAltaPedidio(int nroPedido, string observacionPedido,string nombreCliente,string direccionCliente,long telefonoCliente, string datosReferencia, EstadoPedido estado)
    {
        var pedido = new Pedido(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferencia,EstadoPedido.Ingresado);
        pedidosIngresados.Add(pedido);
    }

    public Pedido BuscarEnIngresados(int nroPedido)
    {
        return pedidosIngresados.Find(pedido => pedido.NroPedido == nroPedido);   
    }

    public bool ExisteArchivo(string rutaArchivo)
    {
        if (File.Exists(rutaArchivo))
        {
            var info = new FileInfo(rutaArchivo);

            if (info.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void CargarListaCadetes(string rutaArchivo, List<Cadete> cadetes)
    {
       if (ExisteArchivo(rutaArchivo))
       {
            using (var infoCadete = new StreamReader(rutaArchivo))
            {
                while (!infoCadete.EndOfStream)
                {
                    string linea = infoCadete.ReadLine();
                    string[] datosCadete = linea.Split(';');

                    int id = int.Parse(datosCadete[0]);
                    string nombre = datosCadete[1];
                    string direccion = datosCadete[2];
                    long telefono = long.Parse(datosCadete[3]);

                    cadetes.Add(new Cadete(id,nombre,direccion,telefono, new List<Pedido>()));
                
                }
            }
       }
    }

    public  Cadeteria CrearCadeteria(string rutaDatosCadeteria)
    {
       Cadeteria cadeteria = null;

        if (ExisteArchivo(rutaDatosCadeteria))
        {
            string[] linea = File.ReadAllLines(rutaDatosCadeteria);
            string primeraLinea = linea[0];
            string[] datosCadeteria = primeraLinea.Split(',');
            string nombre = datosCadeteria[0];
            long telefono = long.Parse(datosCadeteria[1]);
            
            cadeteria = new Cadeteria(nombre,telefono, new List<Cadete>());
        }

        return cadeteria;
        
    }

   

}