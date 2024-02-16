// SignUpController.cs
using EcomwebProjNew.Models; // Assuming you have a UserLogin model
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EcomwebProjNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly UserLoginContext _context;

        public SignUpController(UserLoginContext context)
        {
            _context = context;
        }

        // POST: api/SignUp/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
        {
            try
            {
                // Check if the username already exists
                var existingUser = await _context.SignUpRequests.FirstOrDefaultAsync(u => u.Username == signUpRequest.Username);
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Username already exists" });
                }

                // Check if the email already exists
                var existingEmail = await _context.SignUpRequests.FirstOrDefaultAsync(u => u.Mail == signUpRequest.Mail);
                if (existingEmail != null)
                {
                    return BadRequest(new { message = "Email already exists" });
                }

                // Create a new user
                _context.UserLogins.Add(userLogin);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Signup successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while processing your request." });
            }
        }
    }
}
