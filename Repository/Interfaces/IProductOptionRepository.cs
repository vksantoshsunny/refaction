using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IProductOptionRepository : IRepository<ProductOption>
	{

		IEnumerable<ProductOption> GetAllProductOptionsByProductId(Guid productid);

		ProductOption GetProductOptionsByProductId(Guid productid, Guid id);

		Task AddProductOptionByProductId(Guid productid, ProductOption option);

		Task UpdateProductOptionByProductId(Guid productid, ProductOption option);

		Task RemoveProductOptionByIdAndProductId(Guid productid,Guid id);

		Task AddOrUpdateOptionByProduct(Guid productid, Guid id, ProductOption option);
	}
}
