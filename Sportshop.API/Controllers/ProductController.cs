﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sportshop.Application.Dtos;
using Sportshop.Application.Services;
using Sportshop.Domain.Models;

namespace Sportshop.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductControllerService _service;

        private readonly IMapper _mapper;

        private readonly IResponseService _responseService;

        public ProductController(IProductControllerService service,
            IMapper mapper,
            IResponseService responseService)
        {
            _service = service;
            _mapper = mapper;
            _responseService = responseService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddProduct([FromForm] ProductDto requestedProduct)
        {
            bool result = await _service.ProductDataValidation(requestedProduct);

            if (!result) return BadRequest("message");

            var productThumbnail = await FormatThumbnail(requestedProduct);

            await _service.AddProduct(requestedProduct, productThumbnail);

            var response = _responseService.ProductCreated(requestedProduct);

            return Ok(response);
        }

        private async Task<Thumbnail> FormatThumbnail(ProductDto requestedProduct)
        {
            Thumbnail thumbnail = new Thumbnail();
            thumbnail.Id = Guid.NewGuid();
            thumbnail.Content = requestedProduct.Thumbnail.Content;

            string[] productName = requestedProduct.Name.Split(" ");
            string joinedProductName = string.Empty;

            if (productName.Length < 4)
            {
                joinedProductName = string.Join("_", productName);
            }
            else
            {
                productName = productName
                .Take(3)
                .ToArray();

                joinedProductName = string.Join("_", productName);
            }

            thumbnail.FileName = $"{thumbnail.Id}-{joinedProductName}";
            string path = Path.Combine(@"C:\\Users\\karao\\source\\repos\\sportshop\\Sportshop.Persistence\\Thumbnails",
               thumbnail.FileName);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await thumbnail.Content.CopyToAsync(stream);
            }

            return thumbnail;
        }
    }
}
