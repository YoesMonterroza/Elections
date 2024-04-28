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
    [Route("api/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }         


        [HttpGet]       
        public async Task<IActionResult> Get(PaginationDTO pagination)
        {
             var result = await _userRepository.GetAsync(pagination);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO model)
        {
            var result = await _userRepository.PostAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(User model)
        {
            var result = await _userRepository.UpdateAsync(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _userRepository.DeleteAsync(Id);
            return Ok(result);
        }


    }
}


