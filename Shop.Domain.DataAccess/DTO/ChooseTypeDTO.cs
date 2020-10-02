using Shop.Domain.Models;

namespace Shop.Domain.DataAccess.DTO
{
    public class ChooseTypeDTO
    {
        public int Id { get; set; }
        public ProductType SelectedType { get; set; }
    }
}