using tiendaMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace AplicacionWebEscolar.Controllers
{
    public class FamiliaController : Controller
    {
        public static String uri = System.Configuration.ConfigurationManager.ConnectionStrings["apiTienda"].ToString();

        public ActionResult ObtenerFamiliasPorIdClase(int idClase)
        {
            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync(string.Format("{0}/Familias/?idClase={1}", uri, idClase)).Result;
                Response<List<Familia>> respuesta = new Response<List<Familia>>();

                respuesta = JsonConvert.DeserializeObject<Response<List<Familia>>>(json);

                return Json(respuesta.Data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}