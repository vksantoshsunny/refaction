﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dtos
{
	public class ProductDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public Decimal Price { get; set; }

		public Decimal DeliveryPrice { get; set; }

	}
}
