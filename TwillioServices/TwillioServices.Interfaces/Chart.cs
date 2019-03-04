using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwillioServices.Interfaces
{
    public class Chart
    {
        public string id { get; set; }
        public int time { get; set; }
        public string plan { get; set; }
        public string pkey { get { return "pkey"; } }
    }
}
