using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentPortal.Models
{
    public class Customer
    {
        public int  CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; } 
        public string WorkingArea { get; set; }
        public string Country { get; set; }
        public string Grade { get; set; }
        public string PurchaseAmount { get; set; }
        public int AgentCode { get; set; }
    }
}
