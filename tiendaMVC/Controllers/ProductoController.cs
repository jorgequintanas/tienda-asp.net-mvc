using tiendaMVC.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Globalization;

namespace AplicacionWebEscolar.Controllers
{
    public class ProductoController : Controller
    {
        public String uri = System.Configuration.ConfigurationManager.ConnectionStrings["apiTienda"].ToString();

        public async Task<ActionResult> Index(Producto model = null)
        {
            Producto producto = new Producto();

            if (model != null)
                producto = model;
            
                producto.listaDepartamentos = await DepartamentoController.ObtenerDepartamentos();
                
            return View(producto);
        }
       
        public ActionResult ObtenerProducto(int sku)
        {
            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync(string.Format("{0}/Productos/?sku={1}", uri, sku)).Result;
                Response<Producto> respuesta = new Response<Producto>();

                respuesta = JsonConvert.DeserializeObject<Response<Producto>>(json);

                return Json(respuesta.Data, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult InsertarProducto(Producto producto)
        {
            using (var client = new HttpClient())
            {
                string strFechaActual = DateTime.UtcNow.ToString("yyyy-MM-dd");
                DateTime fechaAlta = DateTime.ParseExact(strFechaActual, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fechaBaja = DateTime.ParseExact("1900-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var strNJsonInsert = new
                {
                    sku = producto.Sku,
                    articulo = producto.Articulo,
                    marca = producto.Marca,
                    modelo = producto.Modelo,
                    departamento = producto.Departamento,
                    clase = producto.Clase,
                    familia = producto.Familia,
                    fecha_alta = fechaAlta.Date,
                    stock = producto.Stock,
                    cantidad = producto.Cantidad,
                    descontinuado = producto.Descontinuado,
                    fecha_baja = fechaBaja.Date
                };

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string json = javaScriptSerializer.Serialize(strNJsonInsert);

                client.BaseAddress = new Uri(uri);

                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(string.Format("{0}/Productos", uri), stringContent).Result;

                return Json(response.IsSuccessStatusCode, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ActualizarProducto(Producto producto)
        {
            using (var client = new HttpClient())
            {
                var strNJsonUpdate = new
                {
                    sku = producto.Sku,
                    articulo = producto.Articulo,
                    marca = producto.Marca,
                    modelo = producto.Modelo,
                    departamento = producto.Departamento,
                    clase = producto.Clase,
                    familia = producto.Familia,
                    fecha_alta = producto.Fecha_Alta,
                    stock = producto.Stock,
                    cantidad = producto.Cantidad,
                    descontinuado = producto.Descontinuado,
                    fecha_baja = producto.Fecha_Baja
                };

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string json = javaScriptSerializer.Serialize(strNJsonUpdate);

                client.BaseAddress = new Uri(uri);

                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PutAsync(string.Format("{0}/Productos", uri), stringContent).Result;

                return Json(response.IsSuccessStatusCode, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EliminarProducto(int sku)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);

                var response = client.DeleteAsync(string.Format("{0}/Productos/?sku={1}", uri, sku.ToString())).Result;

                return Json(response.IsSuccessStatusCode, JsonRequestBehavior.AllowGet);
            }
        }
    }
}