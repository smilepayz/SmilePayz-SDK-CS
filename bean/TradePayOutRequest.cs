namespace gatewatApi;

public class TradePayOutRequest
{


    public string cashAccount{ get ; set ; }
    public string orderNo{ get ; set ; }
    public string purpose{ get ; set ; }
    public int area{ get ; set ; }
    public string paymentMethod { get ; set ; }
    
    public string callbackUrl { get; set; }
    
    public PayerRequest payer{ get; set; }
    public ReceiverRequest receiver{ get; set; }
    
    public TradeAdditionalReq additionalParam{ get; set; }
    public MoneyRequest money{ get; set; }
    public MerchantRequest merchant{ get ; set ; }

}