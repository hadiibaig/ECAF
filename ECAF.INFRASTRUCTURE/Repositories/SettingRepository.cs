using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.Repositories
{
   public class SettingRepository
    {
        private readonly ECAFEntities _db;
        public SettingRepository()
        {
            _db = new ECAFEntities();
        }
        public List<string> GetRoleNames()
        {
            return _db.AspNetRoles.Where(r => r.Name != "Admin").Select(x => x.Name).ToList();
        }
    }
}
