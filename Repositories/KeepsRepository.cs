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

		public void Create(Keep newKeep)
		{
			string sql = @"
                INSERT INTO keeps
                (name, description, img, isPrivate, views, shares, keeps, userId)
                VALUES
                (@Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps, @UserId);";
			_db.Execute(sql, newKeep);
		}



		public void Edit(Keep keep)
		{
			string sql = @"
                UPDATE keeps
                SET
                    name = @Name,
                    description = @Description,
                    img = @Img,
                    isPrivate = @IsPrivate,
                    views = @Views,
                    shares = @Shares,
                    keeps = @Keeps
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