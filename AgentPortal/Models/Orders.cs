using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentPortal.Models
{
    public class Orders
    {
        public int OrderNumber { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustCode { get; set; }
        public int AgentCode { get; set; }




    }
}
