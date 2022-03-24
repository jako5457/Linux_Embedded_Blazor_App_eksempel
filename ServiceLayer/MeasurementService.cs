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

        public MeasurementService(InfluxDBClientOptions InfluxClientOptions)
        {
            _client = InfluxDBClientFactory.Create(InfluxClientOptions);
        }

        public Task<T> GetLatestAsync(string Tag)
        {
            var queryapi = _client.GetQueryApi();
            var result = from h in InfluxDBQueryable<T>.Queryable("TempratureData", "MyOrg", queryapi)
                         where h.Tag == "Humidity"
                         select h;

            return Task.FromResult(result.FirstOrDefault());
        }


        public Task<List<T>> GetMeasurementsAsync(string Tag, DateTime start, DateTime? end = null)
        {
            var queryapi = _client.GetQueryApi();

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
