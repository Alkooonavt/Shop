using System.Collections.Generic;
using Shop.Domain.DataAccess.DTO;

namespace Shop.App.Models
{
    public class IndexDto
    {
    
            public IEnumerable<ProductDTO> Products { get; set; }
            public PageDto Page { get; set; }
        
    }
}