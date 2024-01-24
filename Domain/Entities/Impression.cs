using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Impression
    {
        public string Id { get; set; }
        public int app_id { get; set; }
        public string country_code { get; set; }
        public int advertiser_id { get; set; }
    }
}
