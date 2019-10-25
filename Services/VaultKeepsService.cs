using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
	public class VaultKeepsService
	{
		#region Service Config
		private readonly VaultKeepsRepository _repo;
		private readonly KeepsRepository _kRepo;
		public VaultKeepsService(VaultKeepsRepository repo, KeepsRepository kRepo)
		{
			_repo = repo;
			_kRepo = kRepo;
		}
		#endregion

		public IEnumerable<VaultKeep> Get(int vaultId, string userId)
		// NOTE that _vs and _as have already validated parameters
		{
			// Get the list of VaultKeeps from _repo
			IEnumerable<VaultKeep> vKeeps = _repo.Get(vaultId, userId);
			if (vKeeps == null) { throw new Exception("Invalid Operation"); }
			// Get all of the Keeps on that list from _kRepo
			IEnumerable<Keep> keeps = _kRepo.GetKeepsInVault(vKeeps);
			if (keeps == null) { throw new Exception("Invalid Operation"); }
			return vKeeps;
		}

		public VaultKeep Create(VaultKeep newVKeep)
		{
			//NOTE already validated by _vs and _ks
			int id = _repo.Create(newVKeep);
			// Update keep Count in target keep
			_kRepo.KeepIncrease(newVKeep.KeepId);
			newVKeep.Id = id;
			return newVKeep;
		}

		public string Remove(VaultKeep vKeepToCheck)
		{
			VaultKeep vKeep = Check(vKeepToCheck);//nullcheck
												  // Update keep count in target keep
			_kRepo.KeepDecrease(vKeep.KeepId);
			_repo.Remove(vKeep);
			return "Removed from vault.";
		}

		private VaultKeep Check(VaultKeep vKeepToCheck)
		{
			VaultKeep exists = _repo.Get(vKeepToCheck);
			if (exists == null) { throw new Exception("No matching Keep in Vault."); }
			return exists;
		}



	}
}