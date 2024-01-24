using Application.Dto;
using Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Metric.CalculateMetrics
{
    public class CalculateMetricsHandler : IRequestHandler<CalculateMetricsRequest, List<MetricDto>>
    {
        private readonly IMetricService _metricService;
        public CalculateMetricsHandler(IMetricService metricService)
        {
            _metricService = metricService;
        }
        public Task<List<MetricDto>> Handle(CalculateMetricsRequest request, CancellationToken cancellationToken)
        {
            var metrics = _metricService.CalculateMetrics();
            return Task.FromResult(metrics);
        }       
    }
}
