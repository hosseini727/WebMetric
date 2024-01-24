using Application.Dto;
using Application.Metric.CalculateMetrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webmetric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Metric : ControllerBase
    {
        #region Counstructor
        private readonly IMediator _mediator;
        public Metric(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion Counstructor

        [HttpPost("CalculateMetrics")]
        public async Task<ActionResult<List<MetricDto>>> CalculateMetrics([FromBody] CalculateMetricsRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("CalculateRecommendations")]
        public async Task<ActionResult<List<RecommendationDto>>> CalculateRecommendations([FromBody] CalculateRecommendationsRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }        
    }
}
