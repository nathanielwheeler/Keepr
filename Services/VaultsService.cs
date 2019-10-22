using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
	public class VaultsService
	{
		private readonly VaultsRepository _repo;
		public VaultsService(VaultsRepository repo)
		{
			_repo = repo;
		}


		public IEnumerable<Vault> Get(string userId)
		{
			return _repo.Get(userId);
		}

		public Vault Get(int id, string userId)
		{
			Vault vault = _repo.Get(id);
			if (vault == null) { throw new Exception("_vs: Invalid Id"); }
			if (vault.UserId != userId)
			{
				throw new Exception("That's not your vault!");
			}
			return vault;
		}



		public Vault Create(Vault newVault)
		{
			int id = _repo.Create(newVault);
			newVault.Id = id;
			return newVault;
		}

		public Vault Edit(Vault newVault, string userId)
		{
			Vault vault = Get(newVault.Id, userId);
			vault.Name = newVault.Name;
			vault.Description = newVault.Description;
			_repo.Edit(vault);
			return vault;
		}

		public string Delete(int id, string userId)
		{
			Vault vault = Get(id, userId);
			_repo.Delete(id);
			return "Successfully deleted";
		}
	}
}