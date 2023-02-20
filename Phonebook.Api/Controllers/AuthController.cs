using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Api.Models;

namespace Phonebook.Api.Controllers
{
    public class AuthController: ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            }, user.Password);

            if (result.Succeeded)
            {
                user.Password = "";
                return CreatedAtAction(nameof(Register), new { email = user.Email }, user);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        

    }
}
