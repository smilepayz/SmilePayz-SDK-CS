namespace gatewatApi;

public class PayInRequest
{

    public string orderNo{
        get ;
        set ;
    }
    public string purpose {
        get ;
        set ;
    }
    public int area{
        get ;
        set ;
    }
    public string paymentMethod {
        get ;
        set ;
    }

    public string callbackUrl{
        get;
        set;
    }

    public MoneyRequest money{
        get;
        set;
    }
    public MerchantRequest merchant{
        get ;
        set ;
    }
    
}