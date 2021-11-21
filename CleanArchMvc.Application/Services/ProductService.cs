using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        //public ProductService(IProductRepository productRepository, IMapper mapper)
        //{
        //    _productRepository = productRepository ??
        //        throw new ArgumentNullException(nameof(productRepository));
        //    _mapper = mapper;
        //}

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        //public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        //{
        //    var productsEntity = await _productRepository.GetProductsAsync();
        //    return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        //}

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new Exception($"Entit could not be loaded.");
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        //public async Task<ProductDTO> GetByIdAsync(int? id)
        //{
        //    var productsEntity = await _productRepository.GetByIdAsync(id);
        //    return _mapper.Map<ProductDTO>(productsEntity);
        //}

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
                throw new Exception($"Entit could not be loaded.");
            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    var productsEntity = await _productRepository.GetProductCategoryAsync(id);
        //    return _mapper.Map<ProductDTO>(productsEntity);
        //}

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);
        //    if (productByIdQuery == null)
        //        throw new Exception($"Entit could not be loaded.");
        //    var result = await _mediator.Send(productByIdQuery);
        //    return _mapper.Map<ProductDTO>(result);
        //}

        //public async Task AddAsync(ProductDTO productDto)
        //{
        //    var productsEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.CreateAsync(productsEntity);
        //}

        public async Task AddAsync(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        //public async Task UpdateAsync(ProductDTO productDto)
        //{
        //    var productsEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.UpdateAsync(productsEntity);
        //}

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        //public async Task RemoveAsync(int? id)
        //{
        //    var productsEntity = _productRepository.GetByIdAsync(id).Result;
        //    await _productRepository.RemoveAsync(productsEntity);
        //}

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entit could not be loaded.");
            await _mediator.Send(productRemoveCommand);
        }
    }
}
