using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;


namespace Blazor.Pages.MisProductos
{
	public partial class Productos
	{
		[Inject] IProductoServicio productoServicio { get; set; }

		IEnumerable<Producto> listaProductos { get; set; }

		protected override async Task OnInitializedAsync()
		{
			listaProductos = await productoServicio.GetLista();
		}
    }
}
