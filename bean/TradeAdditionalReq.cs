namespace gatewatApi;

public class TradeAdditionalReq
{
    //Only for India Pay out to Bank (Mandatory)
    public string ifscCode{ get ; set ; }
    //Only for Brazil pay out , which method is CPF/CNPJ ,this is tax number for CPF/CNPJ
    public string taxNumber{ get ; set ; }
    //Only for Thailand pay in which method is BANK,this is means your paying bank account no
    public string payerAccountNo { get; set ; }
}