using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Web.Routing;
using System.Data;

namespace Walmart.Controllers
{
    [HandleError]
    public class LoginController : Controller
    {
        public ICustomFormsAuthenticationService FormsService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new CustomFormsAuthenticationService(); }

            base.Initialize(requestContext);
        }

        public ActionResult LogOn()
        {
            LoginModel model = new LoginModel();
            model.Senha = "Walmart";
            model.Login = "Walmart";

            return View(model);
        }

        [HttpPost]
        public ActionResult LogOn(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (Web.UsuarioProxy.UsuarioServiceClient proxy = new Web.UsuarioProxy.UsuarioServiceClient())
                {
                    var result = proxy.Find(model.Login);

                    if ((result != null) && (result.Length > 0))
                    {
                        if (result.First().Senha.Equals(model.Senha))
                        {
                            FormsService.SignIn(model.Login, false);
                            if (!String.IsNullOrEmpty(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Senha incorreta.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuário não encontrado.");
                    }
                }
            }

            // volta para a view
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("LogOn", "Login");
        }

        public ActionResult About()
        {
            return View();
        }

    }
    
}
