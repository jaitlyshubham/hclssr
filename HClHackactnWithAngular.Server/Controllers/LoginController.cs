using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HClHackactnWithAngular.Server.Model;
using HClHackactnWithAngular.Server.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HClHackactnWithAngular.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthValidation _authValidation;

    public AuthController(IConfiguration configuration, ILogger<AuthController> logger, IAuthValidation authValidation)
    {
        _configuration = configuration;
        _logger = logger;
        _authValidation = authValidation;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        _logger.LogInformation("Login attempt for user: {Username}", loginRequest.Username);

        // Validate the login request
        var validationResult = _authValidation.ValidateLoginRequest(loginRequest);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Invalid login request: {ErrorMessage}", validationResult.ErrorMessage);
            return BadRequest(new { Message = validationResult.ErrorMessage });
        }

        // In a real application, you would authenticate against your database
        // This is a simplified example - replace with actual user authentication
        if (!AuthenticateUser(loginRequest.Username, loginRequest.Password))
        {
            _logger.LogWarning("Authentication failed for user: {Username}", loginRequest.Username);
            return Unauthorized(new { Message = "Invalid username or password" });
        }

        // Create and return the token
        var token = GenerateJwtToken(loginRequest.Username);

        _logger.LogInformation("Login successful for user: {Username}", loginRequest.Username);
        return Ok(new
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(1)
        });
    }

    private bool AuthenticateUser(string username, string password)
    {
        // In a real application, you would authenticate against your user database
        // For demonstration purposes, we'll accept a test user
        // TODO: Replace this with your actual user authentication logic
        return username == "admin@example.com" && password == "Admin@123";
    }

    private string GenerateJwtToken(string username)
    {
        var jwtKey = _configuration["Jwt:Key"] ?? "YourTemporaryKeyHere_AtLeast32CharsLong!";
        var jwtIssuer = _configuration["Jwt:Issuer"] ?? "YourIssuer";
        var jwtAudience = _configuration["Jwt:Audience"] ?? "YourAudience";

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Define claims for the token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username),
            // Add roles or other claims as needed
            new Claim(ClaimTypes.Role, "User")
            // Example for admin: new Claim(ClaimTypes.Role, "Admin")
        };

        // Create the token
        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1), // Token expires after 1 hour
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}