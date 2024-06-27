namespace gatewatApi;

public class TradePayOutRequest
{


    public string cashAccount;

    public string orderNo;

    public string purpose;
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
    public TradeAdditionalReq additionalParam;
    
    public MoneyRequest money{
        get;
        set;
    }
    public MerchantRequest merchant{
        get ;
        set ;
    }

}