using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
	public class VaultKeepsRepository
	{
		private readonly IDbConnection _db;
		public VaultKeepsRepository(IDbConnection db)
		{
			_db = db;
		}



		internal VaultKeep Get(VaultKeep vKeep)
		{
			string sql = @"
                SELECT * FROM vaultkeeps
                WHERE (vaultId = @vaultId AND userId = @userId AND keepId = @keepId)";
			return _db.QueryFirstOrDefault<VaultKeep>(sql, vKeep);
		}

		internal IEnumerable<VaultKeep> Get(int vaultId, string userId)
		{
			string sql = @"
                SELECT * FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId
                WHERE (vaultId = @vaultId AND vk.userId = @userId)";
			return _db.Query<VaultKeep>(sql, new { vaultId, userId });
		}

		internal int Create(VaultKeep newVKeep)
		{
			string sql = @"
				INSERT INTO vaultkeeps
				(vaultId, keepId, userId)
				VALUES
				(@VaultId, @KeepId, @UserId);
				SELECT LAST_INSERT_ID();";
			return _db.ExecuteScalar<int>(sql, newVKeep);
		}

		internal void Remove(VaultKeep vKeep)
		{
			string sql = @"
				DELETE FROM vaultkeeps 
				WHERE (vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId)";
			_db.Execute(sql, vKeep);
		}


	}
}