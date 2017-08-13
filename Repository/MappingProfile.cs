using AutoMapper;
using Domain.Models;
using Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public static class MappingProfile
	{
		public static MapperConfiguration InitializeAutoMapper()
		{
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Product, ProductDto>();
				cfg.CreateMap<ProductDto, Product>();
				cfg.CreateMap<ProductOption, ProductOptionDto>();
				cfg.CreateMap<ProductOptionDto, ProductOption>()
								.ForMember(x => x.Product, opt => opt.Ignore())
								.ForMember(x => x.ProductId, opt => opt.Ignore());
			});

			return config;
		}
	}
}
