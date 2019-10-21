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

		// public IEnumerable<Vault> Get()
		// {
		// 	return _repo.Get();
		// }

		public Vault Get(int id, string userId)
		{
			Vault exists = _repo.Get(id);
			if (exists == null) { throw new Exception("Invalid Id"); }
			if (exists.UserId != userId)
			{
				throw new Exception("That's not your vault!");
			}
			return exists;
		}

		public IEnumerable<Vault> Get(string userId)
		{
			return _repo.Get(userId);
		}

		public Vault Create(Vault newVault)
		{
			int id = _repo.Create(newVault);
			newVault.Id = id;
			return newVault;
		}

		public Vault Edit(Vault newVault)
		{
			Vault vault = _repo.Get(newVault.Id);
			vault.Name = newVault.Name;
			vault.Description = newVault.Description;
			_repo.Edit(vault);
			return vault;
		}

		public string Delete(int id)
		{
			Vault vault = _repo.Get(id);
			if (vault == null) { throw new Exception("Invalid Id"); }
			_repo.Delete(id);
			return "Successfully deleted";
		}
	}
}