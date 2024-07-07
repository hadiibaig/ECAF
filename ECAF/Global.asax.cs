using ECAF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECAF
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AddRoles();
        }

        private void AddRoles()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string[] roleNames = { "payroll", "payroll1", "payroll2", "HR1", "AccountManager", "AppraisalManager" };

            foreach (var roleName in roleNames)
            {
                if (!roleManager.RoleExists(roleName))
                {
                    var role = new IdentityRole(roleName);
                    roleManager.Create(role);
                }
            }
        }
    }
}
