using Elections.Backend.Data;
using Elections.Backend.Repositories.Interfaces;
using Elections.Backend.UnitsOfWork.Interfaces;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Elections.Backend.Controllers
{
    [ApiController]
    [Route("api/Sexes")]
    public class SexesController : ControllerBase
    {
        private readonly ISexesRepository _sexesRepository;

        public SexesController(ISexesRepository sexesRepository)
        {
            _sexesRepository = sexesRepository;
        }         


        [HttpGet]       
        public async Task<IActionResult> GetAll(PaginationDTO pagination)
        {
             var result = await _sexesRepository.GetAsync(pagination);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SexDTO model)
        {
            var result = await _sexesRepository.PostAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Sex model)
        {
            var result = await _sexesRepository.UpdateAsync(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _sexesRepository.DeleteAsync(Id);
            return Ok(result);
        }


    }
}


