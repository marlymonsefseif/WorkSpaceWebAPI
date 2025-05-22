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
        // تأكد من أنه تم تمرير القيم بشكل صحيح
        if (paymentRequest == null || paymentRequest.Amount <= 0)
        {
            return BadRequest("Invalid payment request.");
        }

        var options = new PaymentIntentCreateOptions
        {
            Amount = Convert.ToInt64(paymentRequest.Amount * 100),  // Stripe يتطلب المبلغ بالـ cents
            Currency = paymentRequest.Currency,  // العملة
            Description = paymentRequest.Description  // الوصف (اختياري)
        };

        var service = new PaymentIntentService();
        PaymentIntent paymentIntent = await service.CreateAsync(options);

        return Ok(new { clientSecret = paymentIntent.ClientSecret });
    }


}
