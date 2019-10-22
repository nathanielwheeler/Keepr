using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
	public class KeepsRepository
	{
		private readonly IDbConnection _db;
		public KeepsRepository(IDbConnection db)
		{
			_db = db;
		}

		internal IEnumerable<Keep> Get()
		{
			string sql = "SELECT * FROM keeps WHERE isPrivate = 0"; //SQL can't store true/false, so use 1/0 instead.
			return _db.Query<Keep>(sql);
		}

		internal IEnumerable<Keep> Get(string userId)
		{
			string sql = "SELECT * FROM keeps WHERE userId = @userId";
			IEnumerable<Keep> response = _db.Query<Keep>(sql, new { userId });
			return response;
		}

		internal Keep Get(int id)
		{
			string sql = "SELECT * FROM keeps WHERE id = @id";
			return _db.QueryFirstOrDefault<Keep>(sql, new { id });
		}

		internal IEnumerable<Keep> GetKeepsInVault(IEnumerable<VaultKeep> vKeeps)
		{
			string input = "";
			foreach (VaultKeep vk in vKeeps)
			{
				input += vk.KeepId + ",";
			} // No need to worry about last comma, it goes through SQL fine
			string sql = @"
				SELECT * FROM keeps 
				WHERE id IN (@input);";
			IEnumerable<Keep> response = _db.Query<Keep>(sql, new { input });
			return response;
		}

		public int Create(Keep newKeep)
		{
			string sql = @"
                INSERT INTO keeps
                (name, description, img, isPrivate, views, shares, keeps, userId)
                VALUES
                (@Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps, @UserId);
				SELECT LAST_INSERT_ID();";
			return _db.ExecuteScalar<int>(sql, newKeep);
		}



		public void Edit(Keep keep)
		{
			string sql = @"
                UPDATE keeps
                SET
                    name = @Name,
                    description = @Description,
                    img = @Img
                WHERE id = @Id";
			_db.Execute(sql, keep);
		}

		public void Delete(int id)
		{
			string sql = "DELETE FROM keeps WHERE id = @id";
			_db.Execute(sql, new { id });
		}
	}
}