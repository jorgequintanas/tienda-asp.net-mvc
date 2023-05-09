using tiendaMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace AplicacionWebEscolar.Controllers
{
    public class ClaseController : Controller
    {
        public static String uri = System.Configuration.ConfigurationManager.ConnectionStrings["apiTienda"].ToString();

        public ActionResult ObtenerClasesPorIdDepartamento(int idDepartamento)
        {
            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync(string.Format("{0}/Clases/?idDepartamento={1}", uri, idDepartamento)).Result;
                Response<List<Clase>> respuesta = new Response<List<Clase>>();

                respuesta = JsonConvert.DeserializeObject<Response<List<Clase>>>(json);

                return Json(respuesta.Data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}