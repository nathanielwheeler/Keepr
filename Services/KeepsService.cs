using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
	public class KeepsService
	{
		private readonly KeepsRepository _repo;
		public KeepsService(KeepsRepository repo)
		{
			_repo = repo;
		}

		public IEnumerable<Keep> Get()
		{
			return _repo.Get();
		}

		public IEnumerable<Keep> Get(string userId)
		{
			return _repo.Get(userId);
		}

		public Keep Get(int id)
		{
			Keep exists = _repo.Get(id);
			if (exists == null) { throw new Exception("Invalid Id"); }
			return exists;
		}

		public Keep Create(Keep newKeep)
		{
			newKeep.Views = 0;
			newKeep.Shares = 0;
			newKeep.Keeps = 0;
			int id = _repo.Create(newKeep);
			newKeep.Id = id;
			return newKeep;
		}

		public Keep Edit(Keep newKeep)
		{
			Keep keep = _repo.Get(newKeep.Id);
			if (keep == null) { throw new Exception("Invalid Id"); }
			keep.Name = newKeep.Name;
			keep.Description = newKeep.Description;
			keep.Img = newKeep.Img;
			_repo.Edit(keep);
			return keep;
		}



		public string Delete(int id)
		{
			Keep keep = _repo.Get(id);
			if (keep == null) { throw new Exception("Invalid Id"); }
			_repo.Delete(id);
			return "Successfully delorted";
		}
	}
}