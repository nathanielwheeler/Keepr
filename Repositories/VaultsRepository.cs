using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;

namespace Keepr.Repositories
{
	public class VaultsRepository
	{
		private readonly IDbConnection _db;
		public VaultsRepository(IDbConnection db)
		{
			_db = db;
		}

		internal IEnumerable<Vault> Get()
		{
			throw new NotImplementedException();
		}

		internal Vault Get(int id)
		{
			throw new NotImplementedException();
		}

		internal IEnumerable<Vault> Get(string userId)
		{
			throw new NotImplementedException();
		}

		internal int Create(Vault newVault)
		{
			throw new NotImplementedException();
		}

		internal void Edit(Vault vault)
		{
			throw new NotImplementedException();
		}

		internal void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}