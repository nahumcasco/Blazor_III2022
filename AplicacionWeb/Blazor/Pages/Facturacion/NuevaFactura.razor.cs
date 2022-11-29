using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Modelos;

namespace Blazor.Pages.Facturacion
{
    public partial class NuevaFactura
    {
        [Inject] private IFacturaServicio facturaServicio { get; set; }
        [Inject] private IDetalleFacturaServicio detalleFacturaServicio { get; set; }
        [Inject] private IProductoServicio productoServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
		[Inject] private IHttpContextAccessor httpContextAccessor { get; set; }

		private Factura factura = new Factura();
        private List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        private Producto producto = new Producto();
        private int cantidad { get; set; }
		private string codigoProducto { get; set; }

		protected override async Task OnInitializedAsync()
        {
            factura.Fecha = DateTime.Now;
        }
		private async void BuscarProducto()
		{
			producto = await productoServicio.GetPorCodigo(Convert.ToInt32(codigoProducto));	
		}
		protected async Task AgregarProducto(MouseEventArgs args)
        {
			if (args.Detail != 0)
			{
				if (producto != null)
				{
					DetalleFactura detalle = new DetalleFactura();
					detalle.Producto = producto.Descripcion;
					detalle.CodigoProducto = producto.Codigo;
					detalle.Cantidad = Convert.ToInt32(cantidad);
					detalle.Precio = producto.Precio;
					detalle.Total = producto.Precio * Convert.ToInt32(cantidad);
					listaDetalleFactura.Add(detalle);

					producto.Codigo = 0;
					producto.Descripcion = string.Empty;
					producto.Precio = 0;
					producto.Existencia = 0;
					cantidad = 0;
					codigoProducto = "0";

					factura.SubTotal = factura.SubTotal + detalle.Total;
					factura.ISV = factura.SubTotal * 0.15M;
					factura.Total = factura.SubTotal + factura.ISV - factura.Descuento;
				}

			}
		}

		protected async Task Guardar()
        {
			factura.CodigoUsuario = httpContextAccessor.HttpContext.User.Identity.Name;
			int idFactura = await facturaServicio.Nueva(factura);
			if (idFactura != 0)
			{
				foreach (var item in listaDetalleFactura)
				{
					item.IdFactura = idFactura;
					await detalleFacturaServicio.Nuevo(item);
				}
				await Swal.FireAsync("Felicidades", "Factura guardada con exito", SweetAlertIcon.Success);
			}
			else
			{
				await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
			}
		}

	}
}
