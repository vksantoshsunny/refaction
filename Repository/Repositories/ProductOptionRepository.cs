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
	public class ProductOptionRepository : Repository<ProductOption>, IProductOptionRepository
	{
		public ProductOptionRepository(ApplicationContext Context)
			:base(Context)
		{

		}

		public IEnumerable<ProductOption> GetAllProductOptionsByProductId(Guid productid)
		{
			return Context.ProductOptions.Where(x => x.ProductId == productid).ToList();
		}

		public ProductOption GetProductOptionsByProductId(Guid productid, Guid id)
		{
			return Context.ProductOptions.Where(x => x.ProductId == productid && x.Id == id).FirstOrDefault();
		}

		public async Task UpdateProductOptionByProductId(Guid productid, ProductOption option)
		{
			option.ProductId = productid;
			Context.Entry<ProductOption>(option).State = EntityState.Modified;
			await Context.SaveChangesAsync();
		}

		public async Task AddProductOptionByProductId(Guid productid, ProductOption option)
		{
			option.ProductId = productid;
			Context.ProductOptions.Add(option);
			await Context.SaveChangesAsync();
		}

		public async Task AddOrUpdateOptionByProduct(Guid productid,Guid id, ProductOption option)
		{
			var entity = Context.ProductOptions.Where(x => x.ProductId == productid && x.Id == id).FirstOrDefault();
			if (entity != null)
			{
				entity.Name = option.Name;
				entity.Description = option.Description;
				Context.Entry<ProductOption>(entity).State = EntityState.Modified;
				await Context.SaveChangesAsync();
			}
			else
			{
				option.ProductId = productid;
				Context.ProductOptions.Add(option);
				await Context.SaveChangesAsync();
			}
		}

		public async Task RemoveProductOptionByIdAndProductId(Guid productid, Guid id)
		{
			var entity = Context.ProductOptions.Where(x => x.ProductId == productid && x.Id == id).FirstOrDefault();
			Context.Set<ProductOption>().Remove(entity);
			await Context.SaveChangesAsync();
		}

	}
}
