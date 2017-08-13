using Domain.Models;
using Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IProductRepository ProductRepository { get; }
		IProductOptionRepository ProductOptionRepository { get; }
		int Complete();
	}
}
