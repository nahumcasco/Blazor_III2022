using Blazor.Interfaces;
using Blazor.Servicios;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;
using System;

namespace Blazor.Pages.MisProductos
{
	public partial class EditarProducto
	{
        [Inject] private IProductoServicio productoServicio { get; set; }

        private Producto prod = new Producto();
        [Inject] private SweetAlertService Swal { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }

        [Parameter] public string Codigo { get; set; }

        string imgUrl = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                prod = await productoServicio.GetPorCodigo(Convert.ToInt32(Codigo));
            }
        }
        private async Task SeleccionarIMagen(InputFileChangeEventArgs e)
        {
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            prod.Imagen = buffers;
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(prod.Descripcion))
            {
                return;
            }

            bool edito = await productoServicio.Actualizar(prod);

            if (edito)
            {
                await Swal.FireAsync("Advertencia", "Producto guardado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Productos");
            }
            else
            {
                await Swal.FireAsync("Advertencia", "No se pudo guardar el producto", SweetAlertIcon.Error);
            }
        }
        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Productos");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await productoServicio.Eliminar(Convert.ToInt32(Codigo));

                if (elimino)
                {
                    await Swal.FireAsync("Felifidades", "Producto Eliminado", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Productos");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo Eliminar el producto", SweetAlertIcon.Error);
                }
            }
        }

    }
}
