using InfluxDB.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class Temprature : MeasurementBase
    {
        public static new string BaseTag { get; protected set; } = "TempratureC";

        [Column("value")]
        public double tempratureC { get; set; }
    }
}
