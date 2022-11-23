using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private string CadenaConexon;

        public ProductoRepositorio(string _cadenaConexion)
        {
            CadenaConexon = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexon);
        }

        public async Task<bool> Actualizar(Producto producto)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE producto SET Descripcion = @Descripcion, Existencia = @Existencia, Precio = @Precio, FechaCreacion = @FechaCreacion, 
                               Imagen = @Imagen WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, producto));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<bool> Eliminar(int codigo)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM producto WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { codigo }));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Producto>> GetLista()
        {
            IEnumerable<Producto> lista = new List<Producto>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM producto;";
                lista = await conexion.QueryAsync<Producto>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Producto> GetPorCodigo(int codigo)
        {
            Producto producto = new Producto();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM producto WHERE Codigo = @Codigo;";
                producto = await conexion.QueryFirstOrDefaultAsync<Producto>(sql, new { codigo });
            }
            catch (Exception ex)
            {
            }
            return producto;
        }

        public async Task<bool> Nuevo(Producto producto)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO producto (Codigo, Descripcion, Existencia, Precio, FechaCreacion, Imagen) 
                               VALUES (@Codigo, @Descripcion, @Existencia, @Precio, @FechaCreacion, @Imagen);";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, producto));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }
    }
}
