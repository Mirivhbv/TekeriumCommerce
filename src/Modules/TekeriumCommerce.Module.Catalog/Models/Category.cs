﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TekeriumCommerce.Infrastructure.Models;
using TekeriumCommerce.Module.Core.Models;

namespace TekeriumCommerce.Module.Catalog.Models
{
    public class Category : EntityBase, ILocalizedEntity
    {
        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        [Required]
        [StringLength(450)]
        public string Slug { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }

        public bool IncludeInMenu { get; set; } // fields name staying same but purpose is for show in search form or not

        public bool IsDeleted { get; set; }

        //public long? ParentId { get; set; } // for us no need

        //public Category Parent { get; set; } // for use no need

        //public IList<Category> Children { get; protected set; } = new List<Category>(); // for use no need

        public Media ThumbnailImage { get; set; }

        public IList<LocalizedProperty> Locales { get; set; } = new List<LocalizedProperty>();

        public void AddLocale(LocalizedProperty localizedProperty)
        {
            localizedProperty.EntityId = this.Id;
            this.Locales.Add(localizedProperty);
        }
    }
}