namespace Blazor.Data
{
    //Esta clase es para poder conectar la cadena de appsettings con el programa
    public class MySQLConfiguration
    {
        public string CadenaConexion { get; }

        public MySQLConfiguration(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
    }
}
