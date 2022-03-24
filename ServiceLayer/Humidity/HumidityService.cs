using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB;
using InfluxDB.Client;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Linq;

namespace ServiceLayer.Humidity
{
    internal class HumidityService : IHumidityService
    {
        private InfluxDBClient _client;

        public HumidityService(InfluxDBClientOptions InfluxClientOptions)
        {
            _client = InfluxDBClientFactory.Create(InfluxClientOptions);
        }

        public Task<List<HumidityDto>> GetHumiditiesAsync(DateTime start, DateTime? end = null)
        {
            var queryapi = _client.GetQueryApi();

            if (end == null)
            {
                end = DateTime.Now;
            }

            var query = from h in InfluxDBQueryable<HumidityDto>.Queryable("TempratureData", "MyOrg", queryapi)
                        where h.Time > start
                        where h.Time < end
                        where h.tag == "Humidity"
                        select h;

           return Task.FromResult(query.ToList());
        }

        public Task<HumidityDto> GetLatestHumidityAsync()
        {
            var queryapi = _client.GetQueryApi();
            var result = from h in InfluxDBQueryable<HumidityDto>.Queryable("TempratureData", "MyOrg", queryapi)
                         where h.tag == "Humidity"
                         select h;

            return Task.FromResult(result.FirstOrDefault());
        }
    }
}
