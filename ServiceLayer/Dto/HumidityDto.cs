using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class HumidityDto
    {

        public DateTime Time { get; set; }

        public int Humidity { get; set; }

        public string Host { get; set; } = string.Empty;

    }
}
