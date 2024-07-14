using ECAF.INFRASTRUCTURE.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAF.Controllers
{
    public class FormController : Controller
    {
        private readonly SiteCardRepository siteCardRepository;
        public FormController()
        {
            siteCardRepository = new SiteCardRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ViewForm(long Id , string section = "")
        {
            var data = siteCardRepository.GetFormBYCardId(Id);
            ViewBag.section = section;
            return PartialView("Partial_ViewForms" , data);
        }
        public JsonResult SaveForm(long Id , string text)
        {
            var data = siteCardRepository.SaveComment(Id , text , User.Identity.GetUserId());
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}