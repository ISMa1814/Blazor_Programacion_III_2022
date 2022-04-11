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
    
    public async Task<bool> Actualizar(Usuario usuario)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE usuario SET Codigo = @Codigo, Nombre = @Nombre, Rol = @Rol, Clave = @Clave, EstaActivo = @EstaActivo WHERE Codigo = @Codigo ;";
            resultado = await conexion.ExecuteAsync(sql, new
            {
                usuario.Codigo,
                usuario.Nombre,
                usuario.Rol,
                usuario.Clave,
                usuario.EstaActivo
            });
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Eliminar(Usuario usuario)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "DELETE FROM usuario WHERE Codigo = @Codigo;";
            resultado = await conexion.ExecuteAsync(sql, new { usuario.Codigo });
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
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

    //Metodo para OBTENER el USUARIO con el CODIGO
    public async Task<Usuario> GetPorCodigo(string codigo)
    {
        Usuario user = new Usuario();
        try
        {
            //Using nos ayuda a generar una mejor conexion
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM usuario WHERE Codigo = @Codigo;";
            //Esto es para que muestre la tabla de los usuarios
            user = await conexion.QueryFirstAsync<Usuario>(sql, new {codigo});
        }
        catch (Exception)
        {
        }
        return user;
    }

    //Metodo para CREAR un NUEVO USUARIOS
    public async Task<bool> Nuevo(Usuario usuario)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO usuario (Codigo, Nombre, Rol, Clave, EstaActivo) VALUES (@Codigo, @Nombre, @Rol, @Clave, @EstaActivo)";
            resultado = await conexion.ExecuteAsync(sql, usuario);
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
