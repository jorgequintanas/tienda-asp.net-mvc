using tiendaMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AplicacionWebEscolar.Controllers
{
    public class DepartamentoController : Controller
    {
        public static String uri = System.Configuration.ConfigurationManager.ConnectionStrings["apiTienda"].ToString();

        public static async Task<List<Departamento>> ObtenerDepartamentos()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(string.Format("{0}/Departamentos", uri));
                Response<List<Departamento>> respuesta = new Response<List<Departamento>>();

                respuesta = JsonConvert.DeserializeObject<Response<List<Departamento>>>(json);

                return respuesta.Data;
            }
        }
    }
}