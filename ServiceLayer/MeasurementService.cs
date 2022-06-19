using InfluxDB.Client;
using InfluxDB.Client.Linq;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MeasurementService<T> : IMeasurementService<T> where T : MeasurementBase
    {

        private InfluxDBClient _Client;
        private string _Bucket = "";
        private string _Org = "";

        public MeasurementService(InfluxDBClientOptions.Builder builder,string org,string bucket)
        {
            _Client = InfluxDBClientFactory.Create(builder.Build());
        }

        public Task<T> GetLatestAsync(string Tag)
        {
            var queryapi = _Client.GetQueryApiSync();
            var result = from h in InfluxDBQueryable<T>.Queryable(_Bucket,_Org, queryapi)
                         where h.Tag == Tag
                         select h;

            return Task.FromResult(result.ToList().LastOrDefault());
        }

        public Task<List<T>> GetMeasurementsAsync(string Tag, DateTime start, DateTime? end = null)
        {
            var queryapi = _Client.GetQueryApiSync();

            if (end == null)
            {
                end = DateTime.Now;
            }

            var query = from h in InfluxDBQueryable<T>.Queryable(_Bucket, _Org, queryapi)
                        where h.Time > start
                        where h.Time < end
                        where h.Tag == Tag
                        select h;

            return Task.FromResult(query.ToList());
        }
    }
}
