using Application.Dto;
using Application.Interface;
using Application.Metric.CalculateMetrics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Metric.CalculateRecommendations
{
    public class CalculateRecommendationsHandler : IRequestHandler<CalculateRecommendationsRequest, List<RecommendationDto>>
    {
        private readonly IRecommendationService _recommendationService;

        public CalculateRecommendationsHandler(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        public Task<List<RecommendationDto>> Handle(CalculateRecommendationsRequest request, CancellationToken cancellationToken)
        {
            var recommendations = _recommendationService.CalculateRecommendations();
            return Task.FromResult(recommendations);
        }
    }
}
