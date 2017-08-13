using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IProductRepository : IRepository<Product>
	{
        Task<IEnumerable<Product>> SearchByName(string name)

        Task AddOrUpdate(Guid id, Product product);
	}
}
