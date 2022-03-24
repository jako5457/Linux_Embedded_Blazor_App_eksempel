using InfluxDB.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class Temprature
    {
        [Column("value")]
        public double TempratureC { get; set; }
    }
}
