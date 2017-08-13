using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
	public class ProductConfigure : EntityTypeConfiguration<Product>
	{
		public ProductConfigure()
		{
			Property(x => x.Id)
				.IsRequired();

			Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			Property(x => x.Description)
				.HasMaxLength(500);



		}
	}

	public class ProductOptionConfigure : EntityTypeConfiguration<ProductOption>
	{
		public ProductOptionConfigure()
		{
			Property(x => x.Id)
				.IsRequired();

			Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			Property(x => x.Description)
				.HasMaxLength(500);

			HasRequired(x => x.Product)
				.WithMany(y => y.ProductOptions)
				.HasForeignKey(y => y.ProductId)
				.WillCascadeOnDelete(true);
		}
	}

}
