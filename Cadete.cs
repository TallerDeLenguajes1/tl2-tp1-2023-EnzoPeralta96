namespace GestionPedidos;

public class Cadete
{
    const int PRECIO_ENVIO = 500;
    private int id;
    private string nombre;
    private string direccion;
    private long  telefono;
    private List<Pedido> pedidos;

    public Cadete(int id, string nombre, string direccion, long telefono, List<Pedido> pedidos)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.pedidos = pedidos;
    }

    public int Id { get => id; }
    public string Nombre { get => nombre;}
    public string Direccion { get => direccion;}
    public long Telefono { get => telefono;}
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

    public double JornalACobrar()
    {
        return CantidadPedidosEntregados()*PRECIO_ENVIO;
    }

    public int CantidadPedidosEntregados()
    {
        int cantPedidos = 0;
        foreach (var pedido in pedidos)
        {
            if (pedido.Estado==EstadoPedido.Entregado)
            {
                cantPedidos++;
            }
        }
        return cantPedidos;
    }
    public int CantidadDePedidosRecibidos()
    {
        return pedidos.Count();
    }

    public void RecibirPedido(Pedido nuevoPedido)
    {
        pedidos.Add(nuevoPedido);
    }
    
    public void cambiarEstadoPedido(int nroPedido, EstadoPedido nuevoEstado)
    {
        var pedidoAcambiarEstado = pedidos.Find(pedido => pedido.NroPedido == nroPedido);
            pedidoAcambiarEstado.Estado=nuevoEstado;
    }

    public void EliminarPedido(Pedido pedido)
    {
        pedidos.Remove(pedido);
    }
}