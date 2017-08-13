using Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
	{
		//get
		Task<TEntity> Get(Guid id);
		Task<ICollection<TEntity>> GetAll();

		//add
		Task Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);

		//update
		Task Update(TEntity entity);
		//remove
		Task Remove(Guid id);
		void RemoveRange(IEnumerable<TEntity> entities);

	}
}
