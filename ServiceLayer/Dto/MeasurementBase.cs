using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dto
{
    public class MeasurementBase
    {
        [Column("time")]
        public DateTime Time { get; set; }

        [Column("tag")]
        public string Tag { get; set; } = string.Empty;
    }
}
