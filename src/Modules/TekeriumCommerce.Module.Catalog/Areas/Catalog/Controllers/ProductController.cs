﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;
using TekeriumCommerce.Module.Core.Services;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Product> _productRepository;
        private readonly IMediator _mediator;

        public ProductController(IMediaService mediaService, 
            IRepository<Product> productRepository, 
            IMediator mediator)
        {
            _mediaService = mediaService;
            _productRepository = productRepository;
            _mediator = mediator;
        }

        [HttpGet("product/product-overview")]
        public async Task<IActionResult> ProductOverview(long id)
        {
            var product = await _productRepository.Query()
                .Include(x => x.TyreProfile)
                .Include(x => x.TyreRimSize)
                .Include(x => x.TyreWidth)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsPublished);

            if (product is null)
                return NotFound();

            var model = new ProductDetail
            {
                
            }
        }

        public async Task<IActionResult> ProductDetail(long id)
        {
            var product = await _productRepository.Query()
                .Include(x => x.TyreProfile)
                .Include(x => x.TyreRimSize)
                .Include(x => x.TyreWidth)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsPublished);

            if (product is null)
                return NotFound();

            var model = new ProductDetail
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Specification = product.Specification,

            }
        }
    }
}
