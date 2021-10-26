using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            return View();
        }

        public JsonResult Get()
        {
            ML.Result result = BL.Empleado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update()
        {
            ML.Result result = BL.Empleado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }  
 
        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }
    }
}