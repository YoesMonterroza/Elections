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
    [Route("api/IdType")]
    public class IdentificationTypeController : ControllerBase
    {
        private readonly IIdentificationTypeRepository _identificationTypeRepository;

        public IdentificationTypeController(IIdentificationTypeRepository identificationTypeRepository)
        {
            _identificationTypeRepository = identificationTypeRepository;
        }         


        [HttpGet]       
        public async Task<IActionResult> Get(PaginationDTO pagination)
        {
             var result = await _identificationTypeRepository.GetAsync(pagination);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(IdentificationType model)
        {
            var result = await _identificationTypeRepository.PostAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(IdentificationType model)
        {
            var result = await _identificationTypeRepository.UpdateAsync(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _identificationTypeRepository.DeleteAsync(Id);
            return Ok(result);
        }


    }
}


