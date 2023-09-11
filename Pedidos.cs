namespace GestionCadeteria;

public enum EstadoPedido
{
    Ingresado,
    Entregado, 
    EnCamino,
    Cancelado
}
public class Pedido
{
    private int nroPedido;
    private string observacionPedido;

    private EstadoPedido estado;
    private Cliente cliente;
    private Cadete cadete;

    public int NroPedido { get => nroPedido;}
    public string ObservacionPedido { get => observacionPedido; }
    
    public EstadoPedido Estado { get => estado; set => estado = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }

    public Pedido(int nroPedido, string observacionPedido,string nombreCliente,string direccionCliente,long telefonoCliente, string datosReferencia, EstadoPedido estado)
    {
        this.nroPedido = nroPedido;
        this.observacionPedido = observacionPedido;
        this.cliente = new Cliente(nombreCliente,direccionCliente,telefonoCliente,datosReferencia);
        this.estado = estado;
    }

    public string GetDireccionCliente()
    {
        return cliente.Direccion;
    }

    public string VerDatosCliente()
    {
       return cliente.GetInformacionCliente();
    }



}