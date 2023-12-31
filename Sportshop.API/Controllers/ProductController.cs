﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sportshop.Application.Commands.Products.CreateProduct;
using Sportshop.Application.Commands.Products.DeleteProduct;
using Sportshop.Application.Commands.Products.UpdateProduct;
using Sportshop.Application.Queries.Product.GetProduct;
using Sportshop.Application.Queries.Product.GetProducts;

namespace Sportshop.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> CreateProduct([FromForm] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult> GetProducts()
        {
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{productId}")]
        public async Task<ActionResult> GetProduct(Guid productId)
        {
            var query = new GetProductQuery(productId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateProduct([FromForm]UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteProduct([FromBody]DeleteProductCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
