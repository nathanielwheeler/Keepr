using System;
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

		internal object Get()
		{
			throw new NotImplementedException();
		}

		internal object Get(int id)
		{
			throw new NotImplementedException();
		}

		internal object Get(string userId)
		{
			throw new NotImplementedException();
		}

		internal object Create(Vault newVault)
		{
			throw new NotImplementedException();
		}

		internal object Edit(Vault newVault)
		{
			throw new NotImplementedException();
		}

		internal object Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}