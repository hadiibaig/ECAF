using ECAF.INFRASTRUCTURE.Models;
using ECAF.INFRASTRUCTURE.Repositories;
using ECAF.Models;
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
            var roles = _settingRepository.GetRoleNames();
            return PartialView(roles);
        }
    }
}