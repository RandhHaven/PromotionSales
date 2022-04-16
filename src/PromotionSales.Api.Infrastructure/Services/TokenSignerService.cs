namespace PromotionSales.Api.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Domain.Common;

internal class TokenSignerService : ITokenSignerService
{
    private readonly IConfiguration configuration;

    public TokenSignerService(IConfiguration _configuration)
    {
        this.configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
    }

    public string SignToken(UserResult user)
    {
        var jwtSecret = configuration["AppSettings:Jwt:SecretKey"];
        var issuer = configuration["AppSettings:Jwt:Issuer"];
        var audience = configuration["AppSettings:Jwt:Audience"];
        var expiresIn = int.Parse(configuration["AppSettings:Jwt:expires_in"]);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var jwtExpirationInMinutes = expiresIn;

        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId));
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        claims.Add(new Claim(ClaimTypes.Name, user.UserName ?? String.Empty));

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.UtcNow.AddSeconds(jwtExpirationInMinutes),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        return jwtSecurityTokenHandler.WriteToken(securityToken);
    }
}