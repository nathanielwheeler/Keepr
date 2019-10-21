using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
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

		// internal IEnumerable<Vault> Get()
		// {
		// 	string sql = "SELECT * FROM vaults";
		// 	return _db.Query<Vault>(sql);
		// }

		internal Vault Get(int id)
		{
			string sql = "SELECT * FROM vaults WHERE id = @id";
			return _db.QueryFirstOrDefault<Vault>(sql, new { id });
		}

		internal IEnumerable<Vault> Get(string userId)
		{
			string sql = "SELECT * FROM vaults WHERE userId = @userId";
			IEnumerable<Vault> response = _db.Query<Vault>(sql, new { userId });
			return response;
		}

		internal int Create(Vault newVault)
		{
			string sql = @"
                INSERT INTO vaults
                (name, description, userId)
                VALUES
                (@Name, @Description, @UserId);
				SELECT LAST_INSERT_ID();";
			return _db.ExecuteScalar<int>(sql, newVault);
		}

		internal void Edit(Vault vault)
		{
			string sql = @"
                UPDATE vaults
                SET
                    name = @Name,
                    description = @Description,
                WHERE id = @Id";
			_db.Execute(sql, vault);
		}

		internal void Delete(int id)
		{
			string sql = "DELETE FROM vaults WHERE id = @id";
			_db.Execute(sql, new { id });
		}
	}
}