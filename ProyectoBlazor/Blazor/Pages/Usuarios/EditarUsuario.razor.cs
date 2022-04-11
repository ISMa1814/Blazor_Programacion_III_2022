using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Usuarios;

partial class EditarUsuario
{
    //Los Inject son lo que estan en la clase program
    [Inject] private IUsuarioServicio _usuarioServicio { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    //Nuguet para los botones de guardar, calcelar y eliminar
    [Inject] SweetAlertService Swal { get; set; }
    [Parameter] public string Codigo { get; set; }

    Usuario user = new Usuario();

    protected override async Task OnInitializedAsync()
    {
        if (!string.IsNullOrEmpty(Codigo))
        {
            user = await _usuarioServicio.GetPorCodigo(Codigo);
        }
    }

    //Metodo para guardar el usuario editado
    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
        {
            return;
        }

        bool edito = await _usuarioServicio.Actualizar(user);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Usuario actualizado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Usuario no se pudo actualizar", SweetAlertIcon.Error);
        }
        _navigationManager.NavigateTo("/Usuarios");

    }
    
    //Metodo para cancelar el usuario editado
    protected async Task Cancelar()
    {
        _navigationManager.NavigateTo("/Usuarios");
    }

    //Metodo para eliminar el usuario editado
    protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar el registro?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(result.Value))
        {
            elimino = await _usuarioServicio.Eliminar(user);

            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Usuario eliminado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Usuarios");
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario no se pudo eliminar", SweetAlertIcon.Error);
            }
        }
    }
}

//Metodo para la elecion del rol
enum Roles
{
    Seleccionar,
    Administrador,
    Usuario
}
