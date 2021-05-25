using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using AgentPortal.

namespace AgentPortal.wwwroot
{
    public class AgentListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgentList()
        {
            return View();
        }

    }
}
