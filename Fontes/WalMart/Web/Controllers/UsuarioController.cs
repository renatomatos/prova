using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{

    [HandleError]
    [Authorize]
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            List<Model.UsuarioModel> list = new List<Model.UsuarioModel>();
            try
            {
                using (Web.UsuarioProxy.UsuarioServiceClient proxy = new UsuarioProxy.UsuarioServiceClient())
                {
                    var temp = proxy.List(0);
                    if (temp != null)
                    {
                        list.AddRange(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioController.Index");
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Model.UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Web.UsuarioProxy.UsuarioServiceClient proxy = new UsuarioProxy.UsuarioServiceClient())
                    {
                        var temp = proxy.Find(model.Login);
                        if (temp.Length == 0)
                        {
                            proxy.Add(model);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("Login", "Login já existe");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioController.Add[POST]");
            }
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                using (Web.UsuarioProxy.UsuarioServiceClient proxy = new UsuarioProxy.UsuarioServiceClient())
                {
                    proxy.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioController.Delete");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                using (Web.UsuarioProxy.UsuarioServiceClient proxy = new UsuarioProxy.UsuarioServiceClient())
                {
                    var list = proxy.List(id);

                    // primeiro localiza o registro antes de ir para a pagina
                    if (list.Length > 0)
                    {
                        return View(list.FirstOrDefault());
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioController.Edit[GET]");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Model.UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Web.UsuarioProxy.UsuarioServiceClient proxy = new UsuarioProxy.UsuarioServiceClient())
                    {
                        proxy.Update(model);
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "UsuarioController.Edit[POST]");
            }
            return View(model);
        }

    }
}
