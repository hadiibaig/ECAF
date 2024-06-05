using ECAF.INFRASTRUCTURE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECAF.INFRASTRUCTURE.Models;
using Microsoft.AspNet.Identity;

namespace ECAF.Controllers
{
    [Authorize]
    public class SiteCardController : Controller
    {
        // GET: SiteCard
        public ActionResult SetUpSiteCard()
        {
            return View();
        }

        [HttpPost]
        public string CreateSiteCard(CreateSiteCard siteCard)
        {
            var siteCardRepository = new SiteCardRepository();
            var referenceNumber =  siteCardRepository.CreateSiteCard(siteCard);
            return referenceNumber;

        }

        public ActionResult SetupSiteCardSiteCardSuccess(string referenceNumber)
        {
            ViewBag.ReferenceNumber = referenceNumber;
            return View("~/Views/SiteCard/SetUpSiteCardSuccess.cshtml");

        }
    }

}