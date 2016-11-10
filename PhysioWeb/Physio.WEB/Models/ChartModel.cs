using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysioQA.Models
{
    public class ChartModel
    {
        public string Date { get; set; }
        public int Pain { get; set; }
        public int Work { get; set; }
        public int Family { get; set; }
    }
}