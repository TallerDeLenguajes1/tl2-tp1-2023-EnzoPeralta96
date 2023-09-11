namespace GestionPedidos;

public class Cadeteria
{
    const int PRECIO_ENVIO = 500;
    private string nombre;
    private double telefono;
    private List<Cadete> cadetes;

    private List<Pedido> pedidos;
    public Cadeteria(string nombre, double telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        cadetes = new List<Cadete>();
        pedidos = new List<Pedido>(); 
    }

    public string Nombre { get => nombre;}
    public double Telefono { get => telefono;}
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    public void DarDeAltaPedidio(int nroPedido, string observacionPedido,string nombreCliente,string direccionCliente,long telefonoCliente, string datosReferencia)
    {
        var pedido = new Pedido(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferencia,EstadoPedido.Ingresado);
        pedidos.Add(pedido);
    }

    private Pedido BuscarPedido(int nroPedido)
    {
        return pedidos.Find(pedido => pedido.NroPedido == nroPedido);   
    }

    private Cadete BuscarCadeteXId(int idCadete)
    {
        return cadetes.Find(cadete => cadete.Id == idCadete);
    }

    public void AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        var pedido = BuscarPedido(nroPedido);
        if (pedido!= null)
        {
            pedido.Cadete = BuscarCadeteXId(idCadete);
        }
    }

    public double JornalACobrar(int idCadete)
    {
        return CantidadPedidosEntregados(idCadete)*PRECIO_ENVIO;
    }

    public int CantidadPedidosEntregados(int idCadete)
    {
        int cantPedidos = 0;

        foreach (var pedido in pedidos)
        {
            if (pedido.Estado==EstadoPedido.Entregado && pedido.Cadete.Id == idCadete)
            {
                cantPedidos++;
            }
        }
        return cantPedidos;
    }

    public bool CambiarEstadoPedido(int nroPedido, EstadoPedido nuevoEstado)
    {
        bool EstadoCambiado = false;
        var pedidoAcambiarEstado = BuscarPedido(nroPedido);
        pedidoAcambiarEstado.Estado = nuevoEstado;
        if (pedidoAcambiarEstado.Estado == nuevoEstado)
        {
            EstadoCambiado = true;
        }
        return EstadoCambiado;
    }

    public bool ReasignarCadeteAPedido(int idCadete2, int nroPedido) // idCadete1 : cadete que tiene el pedido || idCadete2: cadete al que le asignare el pedido
    {
        bool pedidoReasignado = false;
        var pedido = BuscarPedido(nroPedido);
        var cadete2 = BuscarCadeteXId(idCadete2);

        if (pedido != null && cadete2 != null)
        {
            pedido.Cadete = cadete2;
            pedidoReasignado = true;
        }
        return pedidoReasignado;
    }

    public bool EliminarPedido(int nroPedido)
    {
        bool pedidoEliminado = false;

        var pedido = BuscarPedido(nroPedido);
        pedidos.Remove(pedido);

        if (BuscarPedido(nroPedido)==null)
        {
            pedidoEliminado = true;
        }
        return pedidoEliminado;
    }

    /*private Pedido BuscarPed(int idCadete, int nroPedido)
    {
        Pedido pedidoBuscado = null;

        Cadete cadeteBuscado = BuscarCadeteXId(idCadete);

        if (cadeteBuscado != null)
        {
            pedidoBuscado = cadeteBuscado.Pedidos.Find(pedido => pedido.NroPedido == nroPedido);
        }


        return pedidoBuscado;
    }*/

    /* public void RecibirPedido(int idCadete, int nroPedido, string observacionPedido,string nombreCliente,string direccionCliente,long telefonoCliente, string datosReferencia)
   {
       var nuevoPedido = darDeAltaPedidio(nroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferencia,EstadoPedido.Ingresado);
       asignarPedidoCadete(idCadete,nuevoPedido);
   }*/

    /*private Pedido BuscarPed(int idCadete, int idPedido)
    {   
        Pedido pedidoBuscado = null;
        foreach (var cadete in cadetes)
        {
            if (cadete.Id == idCadete)
            {
                foreach (var pedido in cadete.Pedidos)
                {
                    if (pedido.NroPedido == idPedido)
                    {
                       pedidoBuscado = pedido;
                    }
                }
            }
        }
        return pedidoBuscado;
    }*/



}