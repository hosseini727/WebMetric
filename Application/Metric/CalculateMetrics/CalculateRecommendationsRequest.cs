using Application.Dto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Metric.CalculateMetrics
{
    public class CalculateRecommendationsRequest : IRequest<List<RecommendationDto>>
    {
        public List<Impression> Impressions { get; set; }
        public List<Click> Clicks { get; set; }
    }
}
