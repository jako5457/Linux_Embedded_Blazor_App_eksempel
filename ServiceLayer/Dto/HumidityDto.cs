using InfluxDB.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class HumidityDto
    {
        [Column("time")]
        public DateTime Time { get; set; }

        [Column("value")]
        public int Humidity { get; set; }

        [Column("tag")]
        public string tag { get; set; } = string.Empty;
    }
}
