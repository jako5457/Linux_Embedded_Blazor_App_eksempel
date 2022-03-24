﻿using InfluxDB.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class Humidity : MeasurementBase
    {

        public static new string BaseTag { get; protected set; } = "Humidity";

        public Humidity()
        {
            BaseTag = "Humidity";
        }

        [Column("value")]
        public int humidity { get; set; }
    }
}
