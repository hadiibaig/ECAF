using System;
using System.Collections.Generic;
using System.Linq;
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
            return _db.AspNetRoles.Select(r => r.Name).ToList();
        }
    }
}
