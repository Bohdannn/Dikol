using System;
using System.Collections.Generic;
using System.Text;

namespace Dikol.Core.Specifications.Params
{
    public class ProductSpecificationParams
    {
        private const int MaxPageSize = 20;
        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? PageSize : value;
        }
        public int PageIndex { get; set; } = 1;
        
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        public string SortBy { get; set; }

        private string _search;
        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
