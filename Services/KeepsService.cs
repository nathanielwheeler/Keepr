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

		public Keep Get(int id, string userId)
		{
			Keep keep = _repo.Get(id);
			if (keep == null) { throw new Exception("Invalid Id"); }
			if (keep.UserId != userId)
			{
				throw new Exception("That's not your keep!");
			}
			return keep;
		}

		public Keep Create(Keep newKeep)
		{
			int id = _repo.Create(newKeep);
			newKeep.Id = id;
			return newKeep;
		}

		public Keep Edit(Keep newKeep, string userId)
		{
			Keep keep = Get(newKeep.Id, userId); //Nullchecks
			keep.Name = newKeep.Name;
			keep.Description = newKeep.Description;
			keep.Img = newKeep.Img;
			_repo.Edit(keep);
			return keep;
		}



		public string Delete(int id, string userId)
		{
			Keep keep = Get(id, userId);//Nullchecks
			_repo.Delete(id);
			return "Successfully delorted";
		}

		public Keep View(int keepId)
		{
			Keep keep = Get(keepId); //Nullcheck
			_repo.View(keepId);
			keep.Views++;
			return keep;
		}

		internal object Share(int keepId)
		{
			Keep keep = Get(keepId); //Nullcheck
			_repo.Share(keepId);
			keep.Views++;
			return keep;
		}


	}
}