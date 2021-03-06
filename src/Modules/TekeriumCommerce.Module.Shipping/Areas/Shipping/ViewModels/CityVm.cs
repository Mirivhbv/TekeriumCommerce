namespace TekeriumCommerce.Module.Shipping.Areas.Shipping.ViewModels
{
    public class CityVm
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string CostString => Cost.ToString("C");
    }
}