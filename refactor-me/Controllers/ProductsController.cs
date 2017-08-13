using System;
using System.Net;
using System.Linq.Expressions;
using System.Linq;
using System.Web.Http;
using Domain.Models;
using System.Threading.Tasks;
using Repository.Interfaces;
using AutoMapper;
using Repository.Dtos;
using refactor_me.ValidationFilter;

namespace refactor_me.Controllers
{
	[RoutePrefix("products")]
	public class ProductsController : ApiController
	{
		IUnitOfWork _unitofwork;
		IMapper _mapper;

		public ProductsController(IUnitOfWork unitofwork, IMapper mapper)
		{
			_unitofwork = unitofwork;
			_mapper = mapper;
		}

		[Route]
		[HttpGet]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> GetAll()
		{
			var products = await (_unitofwork.ProductRepository.GetAll());
			return Ok(products.Select(x => _mapper.Map<ProductDto>(x)));
		}

		[Route]
		[HttpGet]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> SearchByName(string name)
		{
			var products = (_unitofwork.ProductRepository.SearchByName(name.ToLower()));
			return Ok(products.Select(x => _mapper.Map<ProductDto>(x)));
		}

		[Route("{id}")]
		[HttpGet]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> GetProduct(Guid id)
		{
			var product = await _unitofwork.ProductRepository.Get(id);
			return Ok(_mapper.Map<ProductDto>(product));
		}

		[Route]
		[HttpPost]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> Create(ProductDto product)
		{
			await _unitofwork.ProductRepository.Add(_mapper.Map<Product>(product));
			return Ok();
		}

		[Route("{id}")]
		[HttpPut]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> Update(Guid id, ProductDto product)
		{
			await _unitofwork.ProductRepository.AddOrUpdate(id, _mapper.Map<Product>(product));
			return Ok();
		}

		[Route("{id}")]
		[HttpDelete]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> Delete(Guid id)
		{
			await _unitofwork.ProductRepository.Remove(id);
			return Ok();
		}

		[Route("{id}/options")]
		[HttpGet]
		[ValidateModelStateFilter]
		public IHttpActionResult GetOptions(Guid id)
		{
			var options = _unitofwork.ProductOptionRepository.GetAllProductOptionsByProductId(id);
			return Ok(options.Select(x => _mapper.Map<ProductOptionDto>(x)));
		}

		[Route("{id}/options/{optionId}")]
		[HttpGet]
		[ValidateModelStateFilter]
		public IHttpActionResult GetOption(Guid id, Guid optionId)
		{
			var option = _unitofwork.ProductOptionRepository.GetProductOptionsByProductId(id, optionId);
			return Ok(_mapper.Map<ProductOptionDto>(option));

		}

		[Route("{id}/options")]
		[HttpPost]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> CreateOption(Guid id, ProductOptionDto option)
		{
			await _unitofwork.ProductOptionRepository.AddProductOptionByProductId(id, _mapper.Map<ProductOption>(option));
			return Ok();
		}

		[Route("{id}/options/{optionId}")]
		[HttpPut]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> UpdateOption(Guid id, Guid optionId, ProductOptionDto option)
		{
			await _unitofwork.ProductOptionRepository.AddOrUpdateOptionByProduct(id, optionId, _mapper.Map<ProductOption>(option));
			return Ok();
		}

		[Route("{id}/options/{optionId}")]
		[HttpDelete]
		[ValidateModelStateFilter]
		public async Task<IHttpActionResult> DeleteOption(Guid id, Guid optionId)
		{
			await _unitofwork.ProductOptionRepository.RemoveProductOptionByIdAndProductId(id, optionId);
			return Ok();
		}
	}
}
