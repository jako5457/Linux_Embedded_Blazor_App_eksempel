using InfluxDB.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class MeasurementBase
    {
        public static string BaseTag { get; protected set; } = "";

        [Column(IsTimestamp = true)]
        public DateTime Time { get; set; }

        [Column("tag",IsTag = true)]
        public string Tag { get; set; } = string.Empty;
    }
}
