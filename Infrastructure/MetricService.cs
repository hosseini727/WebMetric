using Application.Dto;
using Application.Interface;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MetricService : IMetricService
    {
        public List<MetricDto> CalculateMetrics()
        {
            
            List<Impression> impressions = UtilityHelper.ReadJsonFile<List<Impression>>("impressions.json");
            List<Click> clicks = UtilityHelper.ReadJsonFile<List<Click>>("click.json");

            var metrics = new List<MetricDto>();
            var groupedImpressions = impressions.GroupBy(i => new { i.app_id, i.country_code });
            foreach (var group in groupedImpressions)
            {
                var metric = new MetricDto
                {
                    app_id = group.Key.app_id,
                    country_code = group.Key.country_code,
                    impressions = group.Count(),
                    Clicks = clicks.Count(c => group.Select(i => i.Id).Contains(c.impression_id)),
                    revenue = clicks.Where(c => group.Select(i => i.Id).Contains(c.impression_id)).Sum(c => c.revenue)
                };

                metrics.Add(metric);
            }
            return metrics;
        }        
    }
}
