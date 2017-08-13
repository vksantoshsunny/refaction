using Data;
using Domain.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{

		public ProductRepository(ApplicationContext context)
			:base(context)
		{

		}

		public  async Task<IEnumerable<Product>> SearchByName(string name)
		{
			return await Context.Products.Where(x => x.Name == name.ToLower()).ToListAsync();
		}

		public async Task AddOrUpdate( Guid id, Product product)
		{
			var entity = await Context.Products.FindAsync(id);

			if(entity != null)
			{
				entity.Name = product.Name;
				entity.Description = product.Description;
				entity.DeliveryPrice = product.DeliveryPrice;
				entity.Price = product.Price;
				Context.Entry<Product>(entity).State = EntityState.Modified;
				await Context.SaveChangesAsync();
			}
			else
			{
				Context.Products.Add(product);
				await Context.SaveChangesAsync();
			}

		}

	}
}
