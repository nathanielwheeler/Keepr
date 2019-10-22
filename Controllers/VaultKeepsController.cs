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
	public class VaultKeepsController : ControllerBase
	{
		#region Controller Configuration
		private readonly KeepsService _ks;
		private readonly VaultsService _vs;
		private readonly VaultKeepsService _vks;
		private readonly AccountService _as;
		public VaultKeepsController(KeepsService ks, VaultsService vs, VaultKeepsService vks, AccountService aServ)
		{
			_ks = ks;
			_vs = vs;
			_vks = vks;
			_as = aServ;
		}
		#endregion



		[Authorize]
		[HttpGet("{vaultId}")]
		public ActionResult<IEnumerable<Keep>> Get(int vaultId)
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				Vault vault = _vs.Get(vaultId, user.Id); //This checks to make sure the user owns the vault
				IEnumerable<VaultKeep> vKeeps = _vks.Get(vaultId, user.Id);
				return Ok(vKeeps);
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}

		[Authorize]
		[HttpPost]
		public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVKeep)
		{
			string reqUserId = HttpContext.User.FindFirstValue("Id");
			User user = _as.GetUserById(reqUserId);
			newVKeep.UserId = user.Id;
			//Check if vault is owned by user
			newVKeep.VaultId = _vs.Get(newVKeep.VaultId, newVKeep.UserId).Id;
			//Check if keep exists
			newVKeep.KeepId = _ks.Get(newVKeep.KeepId).Id;
			//Post to vk repo
			return Ok(_vks.Create(newVKeep));
		}

		[Authorize]
		[HttpPut]
		public ActionResult<string> Remove([FromBody] VaultKeep vKeep)
		{
			string reqUserId = HttpContext.User.FindFirstValue("Id");
			User user = _as.GetUserById(reqUserId);
			//Check if vault is owned by user
			vKeep.UserId = _vs.Get(vKeep.VaultId, user.Id).UserId;
			//Remove vKeep
			return Ok(_vks.Remove(vKeep));
		}
	}
}