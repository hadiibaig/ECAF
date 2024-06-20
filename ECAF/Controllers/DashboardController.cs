using ECAF.INFRASTRUCTURE.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAF.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SiteCardRepository siteCardRepository;
        public DashboardController()
        {
            siteCardRepository = new SiteCardRepository();
        }
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;
            string username = User.Identity.Name;
            ViewBag.Username = username;
            var data = siteCardRepository.LoadDashboardData();
            return View(data);
        }
        public PartialViewResult Home()
        {
            string userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;
            string username = User.Identity.Name;
            ViewBag.Username = username;
            return PartialView("Partial_Home");
        }
        public PartialViewResult LoadDashboardData()
        {
            return PartialView("Partial_Home");
        }
    }
}