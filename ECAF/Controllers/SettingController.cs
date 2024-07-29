using ECAF.INFRASTRUCTURE.Models;
using ECAF.INFRASTRUCTURE.Repositories;
using ECAF.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ECAF.Controllers
{
    public class SettingController : Controller
    {
        private readonly SettingRepository _settingRepository;
        public SettingController()
        {
            _settingRepository = new SettingRepository();
        }
        // GET: Setting
        public PartialViewResult Index()
        {
            var model = _settingRepository.GetSettingPageModels();
            return PartialView(model);
        }

        public JsonResult SubmitQuestions(SubmitQuestions model)
        {
            var userId = User.Identity.GetUserId();
            var result = _settingRepository.SaveUsersQuestions(model , userId);
            return Json(result);
        }
        [HttpGet]
        public JsonResult GetQuestions(long FormId)
        {
            var result = _settingRepository.GetQuestions(FormId);
            return Json(result , JsonRequestBehavior.AllowGet);
        }
    }
}