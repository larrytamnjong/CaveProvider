using AutoMapper;
using CaveProvider.Core.Helpers.Responses;
using CaveProvider.Identity.API.Dto;
using CaveProvider.Identity.API.Helpers;
using CaveProvider.Identity.API.Interface;
using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CaveProvider.Identity.API.Database.Context.Interface;
using Azure;

namespace CaveProvider.Identity.API.Controllers
{
    [Route("api/[controller]")]

    public class AuthenticationController : Controller
    {
        IAuthenticationRepository authenticationRepository;


        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] ApplicationUserDto applicationUserDto)
        {

            var result = await authenticationRepository.SignUp(applicationUserDto);
            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status202Accepted, result);
            }

        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] LoginDto loginDto)
        {

            var result = await authenticationRepository.SignIn(loginDto);

            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status404NotFound, result);
            }

            else
            {
                return StatusCode(StatusCodes.Status202Accepted, result);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("signout")]
        public new IActionResult SignOut()
        {
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [Authorize]
        [Route("getsignedinuserdetails")]
        public async Task<IActionResult> GetSignedInUser()
        {

            var userId = User.GetUserId();
            var result = await authenticationRepository.GetSignedInUser(userId);
            return StatusCode(StatusCodes.Status202Accepted, result);


        }
    }
}
