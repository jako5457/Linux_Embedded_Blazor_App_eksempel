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

        private InfluxDBClient _client;

        public MeasurementService(InfluxDBClientOptions.Builder builder)
        {
            _client = InfluxDBClientFactory.Create(builder.Build());
        }

        public Task<T> GetLatestAsync(string Tag)
        {
            var queryapi = _client.GetQueryApiSync();
            var result = from h in InfluxDBQueryable<T>.Queryable("TempratureData", "MyOrg", queryapi)
                         where h.Tag == Tag
                         select h;

            return Task.FromResult(result.ToList().LastOrDefault());
        }


        public Task<List<T>> GetMeasurementsAsync(string Tag, DateTime start, DateTime? end = null)
        {
            var queryapi = _client.GetQueryApiSync();

            if (end == null)
            {
                end = DateTime.Now;
            }

            var query = from h in InfluxDBQueryable<T>.Queryable("TempratureData", "MyOrg", queryapi)
                        where h.Time > start
                        where h.Time < end
                        where h.Tag == Tag
                        select h;

            return Task.FromResult(query.ToList());
        }
    }
}
