//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Stripe;
//using WorkSpaceWebAPI.Models;

//[Authorize(Roles = "Admin")]
//[Route("api/[controller]")]
//[ApiController]
//public class PaymentController : ControllerBase
//{
//    private readonly string _secretKey;

//    public PaymentController(IConfiguration configuration)
//    {
//        _secretKey = configuration["Stripe:SecretKey"];
//    }


//    [HttpPost("create-payment-intent")]
//    public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentRequest paymentRequest)
//    {
//        if (paymentRequest == null || paymentRequest.Amount <= 0)
//        {
//            return BadRequest("Invalid payment request.");
//        }

//        var options = new PaymentIntentCreateOptions
//        {
//            Amount = Convert.ToInt64(paymentRequest.Amount * 100),  
//            Currency = paymentRequest.Currency, 
//            Description = paymentRequest.Description  
//        };

//        var service = new PaymentIntentService();
//        PaymentIntent paymentIntent = await service.CreateAsync(options);

//        return Ok(new { clientSecret = paymentIntent.ClientSecret });
//    }


//}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using WorkSpaceWebAPI.Models;

//[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly string _secretKey;
    
    public PaymentController(IConfiguration configuration)
    {
        _secretKey = configuration["Stripe:SecretKey"];
        StripeConfiguration.ApiKey = _secretKey;  
    }

    [Authorize]
    [HttpPost("create-payment-intent")]
    public async Task<IActionResult> CreateCheckoutSession([FromBody] PaymentRequest paymentRequest)
    {
        if (paymentRequest == null || paymentRequest.Amount <= 0)
        {
            return BadRequest("Invalid payment request.");
        }

        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string>
            {
                "card",
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = Convert.ToInt64(paymentRequest.Amount * 100),  
                        Currency = paymentRequest.Currency,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = paymentRequest.Description,
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:4200/success", 
            CancelUrl = "http://localhost:4200/cancel",   
        };

        var service = new SessionService();
        Session session = await service.CreateAsync(options);

        return Ok(new { clientSecret = session.Id }); 
    }
}
