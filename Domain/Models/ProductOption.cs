using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class ProductOption
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public Guid ProductId { get; set; }

		[JsonIgnore]
		public Product Product { get; set; }
	}
}
