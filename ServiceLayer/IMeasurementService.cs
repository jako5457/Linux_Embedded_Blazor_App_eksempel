using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IMeasurementService<T> where T : MeasurementBase
    {

        public Task<List<T>> GetMeasurementsAsync(string Tag, DateTime start, DateTime? end = null);

        public Task<T> GetLatestAsync(string Tag);

    }
}
