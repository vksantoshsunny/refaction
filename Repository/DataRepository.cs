using Data;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected ApplicationContext Context;

		public Repository(ApplicationContext context)
		{
			Context = context;
		}

		public Task<TEntity> Get(Guid id)
		{
			return Context.Set<TEntity>().FindAsync(id);
		}

		public async Task<ICollection<TEntity>> GetAll()
		{
			return await Context.Set<TEntity>().ToListAsync();
		}

		public async Task Add(TEntity entity)
		{
			try
			{
				Context.Set<TEntity>().Add(entity);
				await Context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				var s = ex.Message;
			}
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().AddRange(entities);
		}

		public async Task Update(TEntity entity)
		{

			Context.Entry<TEntity>(entity).State = EntityState.Modified;
			await Context.SaveChangesAsync();
		}

		public async Task Remove(Guid id)
		{
			var entity = await Context.Set<TEntity>().FindAsync(id);
			Context.Set<TEntity>().Remove(entity);
			await Context.SaveChangesAsync();
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
		}
	}
}
