using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class TempratureDto
    {
        public DateTime Time { get; set; }

        public double TempratureC { get; set; }

        public string Host { get; set; } = string.Empty;
    }
}
