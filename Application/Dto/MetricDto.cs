using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class MetricDto
    {
        public int app_id { get; set; }
        public string country_code { get; set; }
        public int impressions { get; set; }
        public int Clicks { get; set; }
        public double revenue { get; set; }
    }

}
