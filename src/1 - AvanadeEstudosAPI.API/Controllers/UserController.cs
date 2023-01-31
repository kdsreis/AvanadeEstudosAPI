using AutoMapper;
using AvanadeEstudosAPI.API.Utilities;
using AvanadeEstudosAPI.API.ViewModels;
using AvanadeEstudosAPI.Services.DTO;
using AvanadeEstudosAPI.Services.Interfaces;
using AvanadeEstudosAPI.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AvanadeEstudosAPI.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {                 
                var userDTO = _mapper.Map<UserDTO>(userViewModel); 
                var userCreated = await _userService.CreateAsync(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserViewModel UpdateUserViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(UpdateUserViewModel);
                var userUpdated = await _userService.UpdateAsync(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso!",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                await _userService.RemoveAsync(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso!",
                    Success = true,
                    Data = ""
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var user = await _userService.GetAsync(id);

                if (user.Name == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o ID informado.",
                        Success = true,
                        Data = ""
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso!",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }


        [HttpGet]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var allUsers = await _userService.GetAllAsync();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }        
        
    }

}