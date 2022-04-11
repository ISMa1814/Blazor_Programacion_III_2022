﻿using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Usuarios
{
    partial class NuevoUsuario
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] SweetAlertService Swal { get; set; }

        private Usuario user = new Usuario();

        //Metodo para guardar el nuevo usuario
        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
            {
                return;
            }

            bool inserto = await usuarioServicio.Nuevo(user);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Usuario creado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario no se pudo crear", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Usuarios");

        }
        
        //Metodo para cancelar el nuevo usuario
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Usuarios");
        }


    }
}
