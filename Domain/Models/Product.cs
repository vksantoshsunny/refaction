using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Product
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public Decimal Price { get; set; }

		public Decimal DeliveryPrice { get; set; }

		[JsonIgnore]
		public ICollection<ProductOption> ProductOptions { get; set; }
	}
}
