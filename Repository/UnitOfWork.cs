using Data;
using Domain.Models;
using Repository.Dtos;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationContext _context;

		public UnitOfWork(ApplicationContext context)
		{
			_context = context;
			ProductRepository = new ProductRepository(_context);
			ProductOptionRepository = new ProductOptionRepository(_context);

		}

		public IProductRepository ProductRepository { get; private set; }
		public IProductOptionRepository ProductOptionRepository { get; private set; }

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}

	}
}
