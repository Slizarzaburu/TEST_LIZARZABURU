using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_LIZARZABURU.Models
{
    public class ResponseDTO
    {
        public decimal responseDecimal { get; set; }

        public int responseInt { get; set; }

        public string responseString { get; set; }

        public DateTime responseDateTime { get; set; }
    }
}
