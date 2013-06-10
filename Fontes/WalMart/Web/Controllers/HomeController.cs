using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    
    [HandleError]
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MeusDados()
        {
            try
            {
                using (Web.UsuarioProxy.UsuarioServiceClient proxy = new Web.UsuarioProxy.UsuarioServiceClient())
                {
                    var temp = proxy.Find(Model.SessionContextModel.UserName);

                    if (temp.Length > 0)
                    {
                        return View(temp.FirstOrDefault());
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "HomeController.MeusDados[GET]");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult MeusDados(Model.UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Web.UsuarioProxy.UsuarioServiceClient proxy = new Web.UsuarioProxy.UsuarioServiceClient())
                    {
                        proxy.Update(model);
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "HomeController.MeusDados[POST]");
            }
            return View(model);
        }

    }
}
