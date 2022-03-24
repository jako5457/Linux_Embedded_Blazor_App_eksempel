using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Humidity
{
    internal interface IHumidityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spanValue">Value of lengh of Timespan</param>
        /// <param name="timeSpan">the type the Value is</param>
        /// <returns></returns>
        public Task<List<HumidityDto>> GetHumiditiesAsync(DateTime start,DateTime? end = null);

        /// <summary>
        /// Gets latest humidity reading
        /// </summary>
        /// <returns></returns>
        public Task<HumidityDto> GetLatestHumidityAsync();
    }
}
