﻿using System;
using System.Collections.Generic;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class Product : Content
    {
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public int StockQuantity { get; set; }

        public string NormalizedName { get; set; }

        public int DisplayOrder { get; set; }

        public Media ThumbnailImage { get; set; }

        public IList<ProductMedia> Medias { get; protected set; } = new List<ProductMedia>();

        public Brand Brand { get; set; }

        public long? BrandId { get; set; }

        public Category Category { get; set; }

        public long? CategoryId { get; set; }
        
        // by me:
        public long? TyrePofileId { get; set; }

        public TyreProfile TyreProfile { get; set; }

        public long? TyreWidthId { get; set; }

        public TyreWidth TyreWidth { get; set; }

        public long? TyreRimSizeId { get; set; }

        public TyreRimSize TyreRimSize { get; set; }
    }
}