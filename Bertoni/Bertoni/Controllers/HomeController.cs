using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bertoni.Controllers
{
    public class HomeController : Controller
    {
        private const string DATA = @"{""object"":{""name"":""Name""}}";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult ListAlbunes_old()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/albums");
            request.Method = "GET";
            //request.ContentType = "application/json";
            //request.ContentLength = DATA.Length;
            return Json(request.ContentLength, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListAlbunes()
        {
            //Creamos la URL pasando como parámetro el código de país. Ej: PY, AR, US, ES, MX, etc.
            var url = string.Format("https://jsonplaceholder.typicode.com/albums");

            //Creamos la solicitud HTTP.
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            {
                //Obtenemos los datos proveídos por el servicio a través del protocolo HTTP.
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    //Obtenemos el resultado retornado por el servicio
                    var resultado = reader.ReadToEnd();
                    return Json(resultado, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
                }
            }

            //Realizamos la llamada al servicio a través del protocolo HTTP.
            
        }


        public JsonResult listafotos(int idalbum)
        {
            //Creamos la URL pasando como parámetro el código de país. Ej: PY, AR, US, ES, MX, etc.
            var url = string.Format("https://jsonplaceholder.typicode.com/photos?albumId=" + idalbum);

            //Creamos la solicitud HTTP.
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            {
                //Obtenemos los datos proveídos por el servicio a través del protocolo HTTP.
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    //Obtenemos el resultado retornado por el servicio
                    var resultado = reader.ReadToEnd();
                    return Json(resultado, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
                }
            }

            //Realizamos la llamada al servicio a través del protocolo HTTP.

        }

        public JsonResult listacomentarios(int idfoto)
        {
            //Creamos la URL pasando como parámetro el código de país. Ej: PY, AR, US, ES, MX, etc.
            var url = string.Format("https://jsonplaceholder.typicode.com/comments?postId=" + idfoto);

            //Creamos la solicitud HTTP.
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            {
                //Obtenemos los datos proveídos por el servicio a través del protocolo HTTP.
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    //Obtenemos el resultado retornado por el servicio
                    var resultado = reader.ReadToEnd();
                    return Json(resultado, "application/json; charset=utf-8", JsonRequestBehavior.AllowGet);
                }
            }

            //Realizamos la llamada al servicio a través del protocolo HTTP.

        }
    }
}