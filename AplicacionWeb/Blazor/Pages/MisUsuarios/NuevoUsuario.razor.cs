using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;
using CurrieTechnologies.Razor.SweetAlert2;

namespace Blazor.Pages.MisUsuarios
{
	public partial class NuevoUsuario
	{
		[Inject] private IUsuarioServicio usuarioServicio { get; set; }
		[Inject] private NavigationManager navigationManager { get; set; }
		private Usuario user = new Usuario();

		[Inject] SweetAlertService Swal { get; set; }

		protected async void Guardar()
		{
			if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre) 
				|| string.IsNullOrEmpty(user.Clave) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar" )
			{
				return;
			}

			bool inserto = await usuarioServicio.Nuevo(user);

			if (inserto)
			{
                await Swal.FireAsync("Felifidades", "Usuario Guardado", SweetAlertIcon.Success);
            }
			else
			{
                await Swal.FireAsync("Error", "No se pudo guardar el usuario", SweetAlertIcon.Error);
            }

			navigationManager.NavigateTo("/Usuarios");
        }

		protected void Cancelar()
		{
            navigationManager.NavigateTo("/Usuarios");
        }
	}
}

enum Roles
{
    Seleccionar,
	Administrador,
	Usuario
}
