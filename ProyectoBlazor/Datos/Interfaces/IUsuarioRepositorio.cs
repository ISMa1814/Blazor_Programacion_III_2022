using Modelos;

namespace Datos.Interfaces;

public interface IUsuarioRepositorio
{
    //Metodo Asincrono para AGREGAR UN NUEVO USUARIO
    Task<bool> Nuevo(Usuario usuario);

    //Metodo Asincrono para ACTUALIZAR UN USUARIO
    Task<bool> Actualizar(Usuario usuario);

    //Metodo Asincrono para ELIMINAR UN USUARIO
    Task<bool> Eliminar(Usuario usuario);

    //Metodo para MOSTRAR la LISTA de usuarios y poder SELECCIONAR
    Task<IEnumerable<Usuario>> GetLista();

    //Metodo para OBTENER un USUARIO por medio del CODIGO
    Task<Usuario> GetPorCodigo(string codigo);
}
