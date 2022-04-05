using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Usuario
{
    //Este metodo funiona como un ERRORPROVIDE, y se debe de colocar antes del componente
    [Required(ErrorMessage = "El Campo Código es Obligatorio")]
    public string Codigo { get; set; }
    [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "El Campo Rol es Obligatorio")]
    public string Rol { get; set; }
    public string Clave { get; set; }
    public bool EstaActivo { get; set; }
}
