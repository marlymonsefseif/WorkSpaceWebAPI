namespace WorkSpaceWebAPI.Models
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethodId { get; set; }
        public string Description { get; set; }
    }
}
