using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{

    [HandleError]
    [Authorize]
    public class CidadeController : Controller
    {
        private List<SelectListItem> Estados
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();

                using (Web.EstadoProxy.EstadoServiceClient proxy = new Web.EstadoProxy.EstadoServiceClient())
                {
                    foreach (var s in proxy.List(0))
                    {
                        list.Add(new SelectListItem() { Text = s.Sigla, Value = s.Codigo.ToString() });
                    }
                }

                return list;
            }
        }

        private void AddEstadosToViewBag()
        {
            ViewData["uf"] = Estados;
        }        
        
        public ActionResult Index()
        {
            List<Model.CidadeModel> list = new List<Model.CidadeModel>();
            try
            {
                using (Web.CidadeProxy.CidadeServiceClient proxy = new CidadeProxy.CidadeServiceClient())
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
                Utils.HelperLog.WriteText(ex, "CidadeController.Index");
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddEstadosToViewBag();
            
            return View();
        }

        [HttpPost]
        public ActionResult Add(Model.CidadeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Web.CidadeProxy.CidadeServiceClient proxy = new CidadeProxy.CidadeServiceClient())
                    {
                        proxy.Add(model);
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeController.Add[POST]");
            }

            AddEstadosToViewBag();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int codigo)
        {
            try
            {
                Model.CidadeModel[] list = null;

                using (Web.CidadeProxy.CidadeServiceClient proxy = new Web.CidadeProxy.CidadeServiceClient())
                {
                    list = proxy.List(codigo);
                }

                // primeiro localiza o registro antes de ir para a pagina
                if (list.Length > 0)
                {
                    AddEstadosToViewBag();
                    
                    return View(list.FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeController.Edit[GET]");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Model.CidadeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Web.CidadeProxy.CidadeServiceClient proxy = new Web.CidadeProxy.CidadeServiceClient())
                    {
                        proxy.Update(model);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    AddEstadosToViewBag();
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeController.Edit[POST]");
            }
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int codigo)
        {
            try
            {
                using (Web.CidadeProxy.CidadeServiceClient proxy = new CidadeProxy.CidadeServiceClient())
                {
                    proxy.Delete(codigo);
                }
            }
            catch (Exception ex)
            {
                Utils.HelperLog.WriteText(ex, "CidadeController.Delete");
            }
            return RedirectToAction("Index");
        }

    }
}
