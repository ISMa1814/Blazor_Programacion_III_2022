using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    //Esto nos servira para concetarnos de blazor a nuestra base de datos
    private string CadenaConexion;
    //Metodo constructos
    public UsuarioRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }
    
    //Función para poder conectarnos con MySql
    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }

    //Metodos de las INTERFACES, SIEMPRE hay que agregar el async a los metodos asincronos
    
    public Task<bool> Actualizar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    //Metodo para OBTENER la LISTA de USUARIOS
    public async Task<IEnumerable<Usuario>> GetLista()
    {
        IEnumerable<Usuario> lista = new List<Usuario>();

        try
        {
            //Using nos ayuda a generar una mejor conexion
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM usuario;";
            //Esto es para que muestre la tabla de los usuarios
            lista = await conexion.QueryAsync<Usuario>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;
    }

    public Task<Usuario> GetPorCodigo(string codigo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Nuevo(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}
