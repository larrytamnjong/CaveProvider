using AutoMapper;
using CaveProvider.Core.Helpers.Responses;
using CaveProvider.Identity.API.Dto;
using CaveProvider.Identity.API.Interface;
using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.Identity.API.Controllers
{
    [Route("api/[controller]")]

    public class AccountController : Controller
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IMapper mapper;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(IJwtTokenGenerator jwtTokenGenerator,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                IMapper mapper)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] ApplicationUserDto applicationUserDto)
        {
            try
            {
                var exist = await userManager.FindByEmailAsync(applicationUserDto.Email);
                if (exist != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ServiceResponse()
                    { Code = 400, Message = "Account already exist", Success = false });
                }
                else
                {
                    var applicationUser = mapper.Map<ApplicationUser>(applicationUserDto);
                    var result = await userManager.CreateAsync(applicationUser, applicationUserDto.Password);

                    if (!result.Succeeded)
                    {

                        return StatusCode(StatusCodes.Status400BadRequest, new ServiceResponse()
                        { Code = 400, Message = "An error occured, please try again", Success = false });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status201Created, new ServiceResponse()
                        { Code = 200, Message = "Account Created successfully, please login", Success = true });
                    }
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse()
                { Code = 500, Message = ex.Message, Success = false });
            }


        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginDto login)
        {
            try
            {
                var user = await userManager.FindByNameAsync(login.UserName);
              
                
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ServiceResponse()
                    { Code = 400, Message = "User not found", Success = false });
                }
            
                var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);
                if (result.Succeeded)
                {
                   
                        var token = await jwtTokenGenerator.GenerateToken(user);
                        return StatusCode(StatusCodes.Status202Accepted, new ServiceResponse<TokenResponse>()
                        { Code = 400, Message = "Token generated", Success = true, Data = new TokenResponse() { Token = token } });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ServiceResponse()
                    { Code = 400, Message = "Invalid login details, please try again", Success = false });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse()
                { Code = 500, Message = ex.Message, Success = false });
            }
        }
    }
}
