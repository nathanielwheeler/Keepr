using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class KeepsController : ControllerBase
	{
		#region Controller Configuration
		private readonly KeepsService _ks;
		private readonly AccountService _as;
		public KeepsController(KeepsService ks, AccountService aServ)
		{
			_ks = ks;
			_as = aServ;
		}
		#endregion


		[HttpGet("undefined")]
		[HttpDelete("undefined")]
		public BadRequestObjectResult Undefined() { return BadRequest("Undefined Id"); }



		#region Get Methods
		[HttpGet]
		public ActionResult<IEnumerable<Keep>> Get()
		{
			try
			{
				return Ok(_ks.Get());
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[Authorize]
		[HttpGet("user")]
		public ActionResult<IEnumerable<Keep>> GetUserKeeps()
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				string userId = user.Id;
				return Ok(_ks.Get(userId));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}

		[HttpGet("{id}")]
		public ActionResult<Keep> Get(int id)
		{
			try
			{
				return Ok(_ks.Get(id));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}

		#endregion



		[Authorize]
		[HttpPost]
		public ActionResult<Keep> Create([FromBody] Keep newKeep)
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				newKeep.UserId = user.Id;
				return Ok(_ks.Create(newKeep));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

		}

		[Authorize]
		[HttpPut("{id}")]
		public ActionResult<Keep> Edit([FromBody] Keep newKeep, int id)
		{
			try
			{
				newKeep.Id = id;
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				return Ok(_ks.Edit(newKeep, user.Id));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[Authorize]
		[HttpDelete("{id}")]
		public ActionResult<string> Delete(int id)
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				return Ok(_ks.Delete(id, user.Id));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}
	}
}