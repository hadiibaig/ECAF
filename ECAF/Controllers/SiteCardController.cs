using ECAF.INFRASTRUCTURE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECAF.INFRASTRUCTURE.Models;
using Microsoft.AspNet.Identity;
using ECAF.INFRASTRUCTURE;

namespace ECAF.Controllers
{
    [Authorize]
    public class SiteCardController : Controller
    {
        private readonly SiteCardRepository siteCardRepository;
        public SiteCardController()
        {
            siteCardRepository = new SiteCardRepository();
        }
        // GET: SiteCard
        public ActionResult SetUpSiteCard()
        {
            return View();
        }
        public ActionResult UpdateSiteCard()
        {
            return View();
        }
        public ActionResult TerminatingSiteCard()
        {
            return View();
        }
        public ActionResult ECAFForm()
        {
            return View();
        }

        [HttpPost]
        public string CreateSiteCard(CreateSiteCard siteCard)
        {
            var referenceNumber = siteCardRepository.CreateSiteCard(siteCard);
            return referenceNumber;

        }
        [HttpPost]
        public string UpdateSiteCard(UpdateSiteCard siteCard)
        {
            var referenceNumber = siteCardRepository.UpdateSiteCard(siteCard);
            return referenceNumber;

        }
        [HttpPost]
        public string TerminateSiteCard(TerminateSiteCard siteCard)
        {
            var referenceNumber = siteCardRepository.TerminateSiteCard(siteCard);
            return referenceNumber;

        }
        [HttpPost]
        public string CreateECAF(EcafForm siteCard)
        {
            var referenceNumber = siteCardRepository.CreateECAF(siteCard);
            return referenceNumber;

        }

        public ActionResult SetupSiteSuccess(string referenceNumber)
        {
            ViewBag.ReferenceNumber = referenceNumber;
            return View("~/Views/SiteCard/SetUpSiteCardSuccess.cshtml");

        }

        [HttpGet]
        public string GetEmployeesList()
        {

          return  Newtonsoft.Json.JsonConvert.SerializeObject(siteCardRepository.GetEmployeesList());
        }

    }

}