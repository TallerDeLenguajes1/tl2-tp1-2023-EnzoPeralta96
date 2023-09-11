using System.Text;
namespace GestionCadeteria;

public class Cliente
{
    private string nombre;
    private string direccion;

    private long telefono;

    private string datosReferenciaDireccion;

    public Cliente(string nombre, string direccion, long telefono, string datosReferenciaDireccion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosReferenciaDireccion = datosReferenciaDireccion;
    }

    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public long Telefono { get => telefono; }
    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; }

    public string GetInformacionCliente()
    {
        var informacionCliente = new StringBuilder();

        informacionCliente.AppendLine("***** Información del Cliente ******");
        informacionCliente.AppendLine("- Nombre: " + nombre);
        informacionCliente.AppendLine("- Dirección: " + direccion);
        informacionCliente.AppendLine("- Teléfono: " + telefono);
        informacionCliente.AppendLine("- Datos de Referencia de Dirección: " + datosReferenciaDireccion);

        return informacionCliente.ToString();
    }

}