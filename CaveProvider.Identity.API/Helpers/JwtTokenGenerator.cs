using AutoMapper;
using CaveProvider.Identity.API.Dto;
using CaveProvider.Identity.API.Interface;
using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaveProvider.Identity.API.Helpers
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings jwtSettings;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IOptions<IdentityOptions> identityOptions;
        private readonly IMapper mapper;

        public JwtTokenGenerator(
                                IOptions<JwtSettings> jwtOptions,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<ApplicationRole> roleManager,
                                IOptions<IdentityOptions> identityOptions,
                                IMapper mapper)
        {
            jwtSettings = jwtOptions.Value;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.identityOptions = identityOptions;
            this.mapper = mapper;
        }

        public async Task<Token> GenerateToken(ApplicationUser user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret!)),
                SecurityAlgorithms.HmacSha256);

            var claimsFactory = new ClaimsPrincipalFactory(userManager, roleManager, identityOptions);
            var principal = await claimsFactory.CreateAsync(user);
            var claims = principal.Claims;

            var securityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                audience: jwtSettings.Audience,
                claims: claims,
                signingCredentials: signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new Token
            {
                Access_token = token,
                Expires_in = TimeSpan.FromMinutes(jwtSettings.ExpiryMinutes).TotalMilliseconds,
                
            };

        }

    }
}
