using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Usuarios;

//Partial signica que se puede dividir en varios archivos, esto es bueno en proyectos enormes
partial class Usuarios
{
    [Inject] private IUsuarioServicio _usuarioServicio { get; set; }

    private IEnumerable<Usuario> usuariosLista { get; set; }

    protected async override Task OnInitializedAsync()
    {
        usuariosLista = await _usuarioServicio.GetLista();
    }
}
