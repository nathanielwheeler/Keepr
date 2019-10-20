using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
	[Route("/api/[controller]")]
	public class KeepsController : ControllerBase
	{
		private readonly KeepsService _ks;
		private readonly AccountService _as;
		public KeepsController(KeepsService ks, AccountService aServ)
		{
			_ks = ks;
			_as = aServ;
		}

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
				return Ok(_ks.GetUserKeeps(user.Id));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[HttpGet("undefined")]
		public BadRequestObjectResult GetUndefined()
		{
			return BadRequest("Undefined Id");
		}

		[HttpGet("{id}")]
		public ActionResult<Keep> Get(string id)
		{
			try
			{
				return Ok(_ks.Get(id));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}



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
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[Authorize]
		[HttpPut("{id}")]
		public ActionResult<Keep> Edit([FromBody] Keep newKeep, string id)
		{
			try
			{
				newKeep.Id = id;
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				return Ok(_ks.Edit(newKeep));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[Authorize]
		[HttpDelete("{id}")]
		public ActionResult<string> Delete(string id)
		{
			try
			{
				return Ok(_ks.Delete(id));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}
	}
}