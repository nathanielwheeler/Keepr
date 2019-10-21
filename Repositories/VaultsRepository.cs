using System.Data;

namespace Keepr.Repositories
{
	public class VaultsRepository
	{
		private readonly IDbConnection _db;
		public VaultsRepository(IDbConnection db)
		{
			_db = db;
		}
	}
}