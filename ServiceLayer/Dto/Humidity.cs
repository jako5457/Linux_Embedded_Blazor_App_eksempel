using InfluxDB.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class Humidity
    {
        [Column("value")]
        public int Humidity { get; set; }
    }
}
