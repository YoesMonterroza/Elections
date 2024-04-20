﻿using Elections.Backend.Data;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotingStationsController : GenericController<VotingStation>
    {
        private readonly IVotingStationsUnitOfWork _votingStationsUnitOfWork;
        public VotingStationsController(IGenericUnitOfWork<VotingStation> unitOfWork, IVotingStationsUnitOfWork votingStationsUnitOfWork) : base(unitOfWork)
        {
            _votingStationsUnitOfWork = votingStationsUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _votingStationsUnitOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _votingStationsUnitOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

    }
}
