using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using WorkSpaceWebAPI.Models;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly string _secretKey;

    public PaymentController(IConfiguration configuration)
    {
        _secretKey = configuration["Stripe:SecretKey"];
    }


    [HttpPost("create-payment-intent")]
    public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentRequest paymentRequest)
    {
        if (paymentRequest == null || paymentRequest.Amount <= 0)
        {
            return BadRequest("Invalid payment request.");
        }

        var options = new PaymentIntentCreateOptions
        {
            Amount = Convert.ToInt64(paymentRequest.Amount * 100),  
            Currency = paymentRequest.Currency, 
            Description = paymentRequest.Description  
        };

        var service = new PaymentIntentService();
        PaymentIntent paymentIntent = await service.CreateAsync(options);

        return Ok(new { clientSecret = paymentIntent.ClientSecret });
    }


}
