using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgentPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AgentPortal.ViewModels.Agent;

namespace AgentPortal.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AgentData _agentData;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, AgentData agentData)
        {
            _logger = logger;
            _configuration = configuration;
            _agentData = agentData;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AgentList()
        {
            var agList = _agentData.AllAgentsData();
            AgentListViewModel agVM = new AgentListViewModel();
            agVM.agents = agList;
            return View(agVM);
        }

        public IActionResult Agent(string id)
        {
            var agList = _agentData.AllAgentsData();
            AgentListViewModel agVM = new AgentListViewModel();
            agVM.Agent = agList.Where(x => x.AgentCode == id).First();
            return View(agVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
