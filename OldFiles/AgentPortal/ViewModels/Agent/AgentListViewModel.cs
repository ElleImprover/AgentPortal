using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentPortal.Models;

namespace AgentPortal.ViewModels.Agent
{
    public class AgentListViewModel
    {
        public List<Agents> agents { get; set; }

        public Agents Agent { get; set; }

    }
}
