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
	public class VaultsController : ControllerBase
	{
		#region Controller Configuration
		private readonly VaultsService _vs;
		private readonly AccountService _as;
		public VaultsController(VaultsService vs, AccountService aServ)
		{
			_vs = vs;
			_as = aServ;
		}
		#endregion



		[HttpGet("undefined")]
		[HttpDelete("undefined")]
		public BadRequestObjectResult Undefined() { return BadRequest("Undefined Id"); }



		#region Get Methods

		[Authorize]
		[HttpGet]
		public ActionResult<IEnumerable<Vault>> Get()
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				string userId = user.Id;
				return Ok(_vs.Get(userId));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		[HttpGet("{id}")]
		public ActionResult<Vault> Get(int id)
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				return Ok(_vs.Get(id, user.Id));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}
		#endregion



		[Authorize]
		[HttpPost]
		public ActionResult<Vault> Create([FromBody] Vault newVault)
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				newVault.UserId = user.Id;
				return Ok(_vs.Create(newVault));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}

		[Authorize]
		[HttpPut("{id}")]
		public ActionResult<Vault> Edit([FromBody] Vault newVault, int id)
		{
			try
			{
				newVault.Id = id;
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				return Ok(_vs.Edit(newVault, user.Id));
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
				return Ok(_vs.Delete(id, user.Id));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}

	}
}