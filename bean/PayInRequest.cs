namespace gatewatApi;

public class PayInRequest
{

    public string orderNo{ get ; set ; }
    public string purpose { get ; set ; }
    public int area{ get ; set ; }
    public int expiryPeriod{ get ; set ; }
    public string paymentMethod { get ; set ; }
    public string callbackUrl{ get; set; }
    public string redirectUrl{ get; set; }
    public MoneyRequest money{ get; set; }
    public AddressRequest billingAddress{ get; set; }
    public AddressRequest shippingAddress{ get; set; }
    public PayerRequest payer{ get; set; }
    public ReceiverRequest receiver{ get; set; }
    public MerchantRequest merchant{ get ; set ; }
    
}