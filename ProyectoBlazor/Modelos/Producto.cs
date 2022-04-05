using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Producto
{
    //Este metodo funiona como un ERRORPROVIDE, y se debe de colocar antes del componente
    [Required(ErrorMessage = "El Campo Código es Obligatorio")]
    public string Codigo { get; set; }
    [Required(ErrorMessage = "El Campo Descripción es Obligatorio")]
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Existencia { get; set; }
    public byte[] Imagen { get; set; }
}
