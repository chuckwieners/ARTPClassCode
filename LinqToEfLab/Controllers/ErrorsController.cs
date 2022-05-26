using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqToEfLab.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult General()
        {

            //TO view this page, you must go to the global.asax and code the Application_Error()
            return View();
        }

        public ActionResult PageNotFound404()
        {
            //this reference can be set in the ROOT web.config (see notes) or the Global.asax.
            return View();
        }
    }
}