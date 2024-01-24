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
    public class RecommendationService : IRecommendationService
    {
        public List<RecommendationDto> CalculateRecommendations()
        {

            List<Impression> impressions = UtilityHelper.ReadJsonFile<List<Impression>>("impressions.json");
            List<Click> clicks = UtilityHelper.ReadJsonFile<List<Click>>("click.json");

            var metricsResult = CalculateMetrics(impressions, clicks);

            var recommendations = new List<RecommendationDto>();

            var groupedImpressions = metricsResult.GroupBy(i => new { i.app_id, i.country_code });
            foreach (var group in groupedImpressions)
            {
                var topAdvertiserIds = group.OrderByDescending(m => m.revenue / m.impressions)
                                            .Take(5)
                                            .Select(m => m.app_id)
                                            .ToList();

                var recommendation = new RecommendationDto
                {
                    AppId = group.Key.app_id,
                    CountryCode = group.Key.country_code,
                    RecommendedAdvertiserIds = topAdvertiserIds
                };             

                recommendations.Add(recommendation);
            }

            return recommendations;
        }

        #region CalculateMetrics
        /// <summary>
        /// CalculateMetrics
        /// </summary>
        /// <param name="impressions"></param>
        /// <param name="clicks"></param>
        /// <returns></returns>
        static List<MetricDto> CalculateMetrics(List<Impression> impressions, List<Click> clicks)
        {
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
        #endregion CalculateMetrics
      
    }
}
