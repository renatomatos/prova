using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel.Web;

namespace Walmart.Controllers
{
    [HandleError]
    [Authorize]
    public class EstadoController : Controller
    {
        public ActionResult Index()
        {
            List<Model.EstadoModel> list = new List<Model.EstadoModel>();
            try
            {
                using (Web.EstadoProxy.EstadoServiceClient proxy = new Web.EstadoProxy.EstadoServiceClient())
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
                Utils.HelperLog.WriteText(ex, "EstadoController.Index");
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Model.EstadoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Web.EstadoProxy.EstadoServiceClient proxy = new Web.EstadoProxy.EstadoServiceClient())
                    {
                        proxy.Add(model);
                    }
                    
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoController.Add[POST]");
            }
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int codigo)
        {
            try
            {
                using (Web.EstadoProxy.EstadoServiceClient proxy = new Web.EstadoProxy.EstadoServiceClient())
                {
                    proxy.Delete(codigo);
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoController.Delete");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int codigo)
        {
            try
            {
                Model.EstadoModel[] list = null;
                
                using (Web.EstadoProxy.EstadoServiceClient proxy = new Web.EstadoProxy.EstadoServiceClient())
                {
                    list = proxy.List(codigo);
                }
                
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
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoController.Edit[GET]");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Model.EstadoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Web.EstadoProxy.EstadoServiceClient proxy = new Web.EstadoProxy.EstadoServiceClient())
                    {
                        proxy.Update(model);
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "EstadoController.Edit[POST]");
            }
            return View(model);
        }
    }
}
