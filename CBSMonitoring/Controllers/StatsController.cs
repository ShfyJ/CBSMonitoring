﻿using CBSMonitoring.Constants;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequirePasswordChange")]
    public class StatsController : ControllerBase
    {
        private readonly IRankingService _rankingService;
        private readonly IQuestionBlockService _questionBlockService;
        public StatsController(IRankingService rankingService, 
            IQuestionBlockService questionBlockService)
        {
            _rankingService = rankingService;
            _questionBlockService = questionBlockService;
        }

        [HttpGet("GetScoreStatsForPeriod")]
        public async Task<IActionResult> GetScoreStatisticsForPeriod(int periodOfQuarters, int organizationId)
        {
            var result = await _rankingService.GetStatisticsForPeriod(periodOfQuarters, organizationId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetAllInOneStatsForPeriod")]
        public async Task<IActionResult> GetAllInOneStatiscticsForPeriod(int periodOfQuarters)
        {
            var result = await _rankingService.GetAllInOneStatiscticsForPeriod(periodOfQuarters);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetStatsForCriteria")]
        public async Task<IActionResult> GetStatsForCriteria(double percentageCriteria, int periodOfQuarters)
        {
            var result = await _rankingService.GetStatsForCriteria(percentageCriteria, periodOfQuarters);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetStatsOfCompletionForPeriod")]
        public async Task<IActionResult> GetStatsOfCompletion(int periodOfQuarters, int organizationId)
        {
            var result = await _questionBlockService.GetStatsForReportCompletion(periodOfQuarters, organizationId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("GetOverallStatsOfCompletionForPeriod")]
        public async Task<IActionResult> GetOverallStatsOfCompletion(int periodOfQuarters)
        {
            var result = await _questionBlockService.GetAllInOneStatsForReportCompletion(periodOfQuarters);

            return StatusCode(result.StatusCode, result);
        }
    }
}
