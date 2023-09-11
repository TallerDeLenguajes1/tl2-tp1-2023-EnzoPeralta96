using System.Text.Json;
using GestionPedidos;

public abstract class AccesoADatos
{
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
    public abstract void CargarCadetes(string rutaArchivo, List<Cadete> cadetes);
    public abstract Cadeteria CrearCadeteria(string rutaDatosCadeteria);


}
public class AccesoCSV : AccesoADatos
{    

    public override Cadeteria CrearCadeteria(string rutaDatosCadeteria)
    {
       Cadeteria cadeteria = null;

        if (ExisteArchivo(rutaDatosCadeteria))
        {
            string[] linea = File.ReadAllLines(rutaDatosCadeteria);
            string primeraLinea = linea[0];
            string[] datosCadeteria = primeraLinea.Split(',');
            string nombre = datosCadeteria[0];
            long telefono = long.Parse(datosCadeteria[1]);
            
            cadeteria = new Cadeteria(nombre,telefono);
        }

        return cadeteria; 
    }
    public override void CargarCadetes(string rutaArchivo, List<Cadete> cadetes)
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
                    cadetes.Add(new Cadete(id,nombre,direccion,telefono));     
                }
            }
       }
    }

   
}

public class AccesoJSON : AccesoADatos
{
    private List<Cadete> LeerJsonCadetes(string rutaArchivo)
    {
        var cadetes = new List<Cadete>();

        if(ExisteArchivo(rutaArchivo))
        {
            string TextoJson = File.ReadAllText(rutaArchivo);

            if (!string.IsNullOrEmpty(TextoJson))//redundante
            {
                cadetes = JsonSerializer.Deserialize<List<Cadete>>(TextoJson);
            }
        }
        return cadetes;
    }

    public override void CargarCadetes(string rutaArchivo, List<Cadete> cadetes)
    {
        cadetes = LeerJsonCadetes(rutaArchivo);
    }

    public override Cadeteria CrearCadeteria(string rutaArchivo)
    {
        Cadeteria cadeteria = null;
        if (ExisteArchivo(rutaArchivo))
        {
            string TextoJson = File.ReadAllText(rutaArchivo);
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(TextoJson);
        }
        return cadeteria;
    }
}