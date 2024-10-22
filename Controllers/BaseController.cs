using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Korntest.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            ViewBag.ProjectName = "Transportation";
            ViewBag.ProjectVersion = "1.0.0";
            ViewBag.ProjectId = "TR2024-01";

            if (String.IsNullOrEmpty(User.Identity.Name))
            {
                ViewBag.Name = "Guest";
            }
            else
            {
                var role = IdentityExtentions.GetRole(HttpContext.User);
                ViewBag.Role = role;
                ViewBag.Name = User.Identity.Name;
                ViewBag.Surname = IdentityExtentions.GetSurname(HttpContext.User);
                ViewBag.Token = IdentityExtentions.GetToken(HttpContext.User);
            }
            
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}