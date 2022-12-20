using System;
using Manager.API.ViewModels;
using Manager.Core.Exeptions;
using Microsoft.AspNetCore.Mvc;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;
using Manager.API.Utilities;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase{

        private readonly IUserServices _userService;
        private readonly IMapper _mapper;

        public UserController(IUserServices userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create(CreateUserViewModel user)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(user);

                var userCreated = await _userService.Create(userDTO);
                
                return Ok(new ResultViewModel{
                    Message = "Usuário criado com sucesso"
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/getuser")]
        public Task<IActionResult> Get(int id)
        {
            try
            {
                var user = _userService.
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}