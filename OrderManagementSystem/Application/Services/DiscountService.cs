namespace OrderManagementSystem.Application.Services
{
    public class DiscountService
    {
        public decimal CalculateDiscount(decimal subtotal)
        {
            if (subtotal > 200) return subtotal * 0.10m; 
            if (subtotal > 100) return subtotal * 0.05m; 
            return 0;
        }
    }
}