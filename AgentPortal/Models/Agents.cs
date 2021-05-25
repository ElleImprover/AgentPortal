using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AgentPortal.Models
{
    public class Agents
    {
        [Required, StringLength(4)]
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string WorkingArea { get; set; }
        public decimal Commission { get; set; }

        [ StringLength(10)]
        public long PhoneNumber { get; set; }

    }
}
