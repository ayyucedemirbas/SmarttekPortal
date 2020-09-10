using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busines;
using Entities;

namespace SmarttekPortal.Controllers
{
    
    public class GirisController : Controller
    {
        // GET: Giris
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User data)
        {
            if (data.Mail != null)
            {
                //Giriş İşlemi Yap
                Manager mng = new Manager();
                BusinesLayerResult<User> res = mng.Login(data.Mail, data.Sifre);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(data);
                }
                Session["login"] = res.result;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}