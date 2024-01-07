/*
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;

namespace server.Controllers
{

	[Route("api/User")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;

		public UserController(ApplicationDbContext context)
		{
			_context = context;
		}

		// POST: api/User/Login
		[HttpPost("Login")]
		public ActionResult<UserEntity> Login([FromBody] UserEntity login)
		{
			var user = _context.Users
				.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

			if (user == null)
			{
				return Unauthorized("Invalid username or password.");
			}

			//generate a token here and return it
			return Ok(user);
		}

		// POST: api/User/Register 
		[HttpPost("Register")]
		public ActionResult<UserEntity> Register([FromBody] UserEntity newUser)
		{
			//check if the username exists and hash the password

			_context.Users.Add(newUser);
			_context.SaveChanges();

			//return a DTO (Data Transfer Object) instead ?
			return CreatedAtAction("Register", new { id = newUser.Id }, newUser);
		}

	}
}
*/