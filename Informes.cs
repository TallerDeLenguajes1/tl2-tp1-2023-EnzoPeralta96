using GestionPedidos;

public class Informes
{
    public static void InformeFinalJornada(Cadeteria cadeteria)
    {
       Console.WriteLine("Cantidad total de pedidos::"+cadeteria.CantidadPedidosRecibidos());
       Console.WriteLine();
       Console.WriteLine("Cantidad de pedidos en estado INGRESADOS:"+cadeteria.CantidadPedidosEnCamino());
       Console.WriteLine();
       Console.WriteLine("Cantidad de pedidos EN CAMINO:"+cadeteria.CantidadPedidosEnCamino());
       Console.WriteLine();
       Console.WriteLine("Cantidad de pedidos ENTREGADOS:"+cadeteria.CantidadPedidosEntregados());
       Console.WriteLine();
       Console.WriteLine("Cantidad de pedidos CANCELADOS:"+cadeteria.CantidadPedidosCancelados());

       Console.WriteLine("Pagos a cadetes:");
       foreach (var cadete in cadeteria.Cadetes )
       {
            Console.WriteLine("-ID{0}\n-Nombre:{1}\n-Total a cobrar ---> {2}",cadete.Id,cadete.Nombre,cadeteria.JornalACobrar(cadete.Id));
            Console.WriteLine();
       }
    }


}