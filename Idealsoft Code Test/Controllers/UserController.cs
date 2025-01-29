using Application.Interfaces;
using Domain.Entities;
using Idealsoft_Code_Test.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Idealsoft_Code_Test.Controllers
{

    [ApiController]
    [Route("api/")]
    public class UserController : Controller
    {
        private IUserApplication _application;
            
        public UserController(IUserApplication application)
        {
            _application = application ?? throw new ArgumentNullException(nameof(application));
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _application.GetAllUsers(); //calls application that calls repository
                return Ok(new ApiResponse<List<User>>(users, "Users retrieved successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(ex, "An unexpected error ocurred trying to get all users..", false));
            }
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = _application.GetById(id).Result;
                if (user == null)
                {
                    return NotFound(new ApiResponse<object>(null, $"User with id = {id} not found.", false));
                }

                return Ok(new ApiResponse<User>(user, "The user was retrieved successfully.", true));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(ex, $"An unexpected error occurred trying to get a user with id = {id}", false));
            }
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                await _application.CreateUser(user); //calls application that calls repository
                return Ok(new ApiResponse<User>(user, "The user was created successfully.", true));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(null, $"An unexpected error ocurred trying to create an user. {ex.Message}", false));
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Put(User user)
        {
            try
            {
                var users = await _application.UpdateUser(user); //calls application that calls repository
                return Ok(new ApiResponse<User>(users, $"The user with id {user.Id} was updated successfully.", true));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(null, $"An unexpected error ocurred trying to update an user. {ex.Message}", false));
            }
        }

        [HttpDelete("DeleteUserById")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool success = await _application.DeleteUser(id); //calls application that calls repository
                if (!success)
                {
                    return NotFound(new ApiResponse<object>(null, $"User with id = {id} not found.", false));
                }
                return Ok(new ApiResponse<object>(null, $"The user with id {id} was deleted successfully.", true));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>(null, $"An unexpected error ocurred trying to delete an user. {ex.Message}", false));
            }
        }
    }
}
