namespace gatewatApi;

public class Constant
{
    
    
    public const string privateKeyStr = "merchant private key ";
 

    public const string baseUrlSanbox = "https://sandbox-gateway.smilepayz.com";
    public const string baseUrl = "https://gateway.smilepayz.com";
    public const string merchantId = "your merchant id ";
    public const string merchantIdSandBox = "your merchant id in sandbox";
    public const string merchantSecret = "merchant secret";
    public const string merchantSecretSandBox = "merchant sercret insandbox";
    
    //for pay-in order
    public const int tradeTypePayIn = 1;
    //for pay-out order
    public const int tradeTypePayOut = 2;

}
