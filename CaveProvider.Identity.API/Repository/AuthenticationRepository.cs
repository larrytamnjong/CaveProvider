using CaveProvider.Core.Helpers.Responses;
using CaveProvider.Identity.API.Dto;
using CaveProvider.Identity.API.Interface;
using AutoMapper;
using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using CaveProvider.Identity.API.Database.Context.Interface;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CaveProvider.Identity.API.Repository
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IMapper mapper;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IApplicationDbContext context;
        private readonly IRoleRepository roleRepository;
        public AuthenticationRepository(IJwtTokenGenerator jwtTokenGenerator, 
                                 SignInManager<ApplicationUser> signInManager,
                                 UserManager<ApplicationUser> userManager,
                                 IApplicationDbContext context,
                                 IRoleRepository roleRepository,
                                 IMapper mapper)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
            this.roleRepository = roleRepository;
        }

        public async Task<ServiceResponseBase> SignUp(ApplicationUserDto applicationUserDto)
        {
            try
            {
                if (userManager.Users.Count() < 1)
                {
                    var user = await userManager.FindByEmailAsync(applicationUserDto.Email);
                    if (user != null)
                    {
                        return new ServiceResponse() { Code = 400, Errors = ["Account already exist"], Success = false };
                    }
                    else
                    {
                        var applicationUser = mapper.Map<ApplicationUser>(applicationUserDto);
                        var result = await userManager.CreateAsync(applicationUser, applicationUserDto.Password);

                        if (!result.Succeeded)
                        {
                            var errors = result.Errors.Select(error => error.Description).ToList();

                            return new ServiceResponse() { Code = 400, Errors = errors, Success = false };
                        }
                        else
                        {
                            user = await userManager.FindByEmailAsync(applicationUserDto.Email);
                            await roleRepository.AssignAllRolesToUser(user!);
                            var token = await jwtTokenGenerator.GenerateToken(user!);

                            return new ServiceResponse<Token> { Messages = ["Administrator account was successfully created"], Data = token, Success = true };
                        }
                    }
                }
                else
                {
                    return new ServiceResponse() { Errors = ["Administrator account has already been created. Please request account creation from the administrator."], Success = false, Code = 400 };
                }
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResponseBase> SignIn(LoginDto loginDto)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(loginDto.Email);


                if (user == null)
                {
                    return  new ServiceResponse(){ Code = 404, Errors = ["User not found"], Success = false };
                }

                var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (result.Succeeded)
                {
                    var token = await jwtTokenGenerator.GenerateToken(user);
                   return new ServiceResponse<Token> { Messages = ["Access granted"], Data = token, Success = true };
                }
                else
                {
                    return new ServiceResponse() { Code = 400, Errors = ["Invalid login details, please try again"], Success = false };
                }
            }
            catch(Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<ApplicationUserDto> GetSignedInUser(string userId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);
                return mapper.Map<ApplicationUserDto>(user);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
