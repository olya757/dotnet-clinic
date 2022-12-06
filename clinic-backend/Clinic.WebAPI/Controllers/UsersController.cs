using AutoMapper;
using Clinic.Services.Abstract;
using Clinic.Services.Models;
using Clinic.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.WebAPI.Controllers
{
    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]                               // http://vk.com/profile/1 -> html page
    [Route("api/v{version:apiVersion}/[controller]")] // http://vk.com/api/v1/profile/1 -> http response with code and body
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        /// <summary>
        /// Doctors controller
        /// </summary>
        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get users by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")] // /users?limit=20&offset=0
        public IActionResult GetUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = userService.GetUsers(limit, offset);

            var response = mapper.Map<PageResponse<UserPreviewResponse>>(pageModel);

            return Ok(response); // code 200 + body
        }

        /// <summary>
        /// Update user
        /// </summary>
        [HttpPut]
        [Route("{id}")] // http://localhost/api/v1/users/id
        [Authorize]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = userService.UpdateUser(id, mapper.Map<UpdateUserModel>(model));

                return Ok(mapper.Map<UserResponse>(resultModel));
            }
            catch (Exception ex) // todo ServiceException ex 400
            {
                return BadRequest(ex.ToString()); //400 
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                var userModel = userService.GetUser(id);
                return Ok(mapper.Map<UserResponse>(userModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
