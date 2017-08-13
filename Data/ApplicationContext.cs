using Domain.Models;
using Data.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext() : base("Name=ProductContext")
		{

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<ProductOption> ProductOptions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Configurations.Add(new ProductConfigure());
			modelBuilder.Configurations.Add(new ProductOptionConfigure());
		}
	}
}
