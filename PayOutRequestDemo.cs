using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gatewatApi;

public class PayOutRequestDemo
{
    public static async Task PayOutDemo()
    {
        // sandbox 
        // string requestPath =Constant.baseUrlSanbox + "/v2.0/disbursement/pay-out";
        // string merchantId = Constant.merchantIdSandBox;
        // string merchanteSerct = Constant.merchantSecretSandBox;
        
        // prdoction
        string requestPath = Constant.baseUrl +"/v2.0/disbursement/pay-out";
        string merchantId = Constant.merchantId;
        string merchanteSerct = Constant.merchantSecret;
        
        
        string orderNo = merchantId.Replace("sandbox-", "S") + Guid.NewGuid().ToString("N");

        
        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        //demo for INDONESIA ,replace currency to you what need
        MoneyRequest moneyRequest = new MoneyRequest();
        moneyRequest.amount = 200000;
        moneyRequest.currency = CurrencyEnum.INR.ToString();

        MerchantRequest merchantRequest = new MerchantRequest();
        merchantRequest.merchantId = merchantId;
        
        TradeAdditionalReq additionalReq = new TradeAdditionalReq();
        //ifscCode is required for INR transaction
        additionalReq.ifscCode = "YESB0000097";
        //required for BRL transaction
        additionalReq.taxNumber = "12345678890";
        
        //fixme demo for INDONESIA  ,replace paymentMethod,area to you what need
        TradePayOutRequest payOutRequest = new TradePayOutRequest();
        payOutRequest.cashAccount = "17385238451";
        payOutRequest.merchant = merchantRequest;
        payOutRequest.money = moneyRequest;
        payOutRequest.paymentMethod = "BCA";
        payOutRequest.area = AreaEnum.INDONESIA.Code;
        payOutRequest.purpose = "for test";
        payOutRequest.additionalParam = additionalReq;
        payOutRequest.orderNo = orderNo.Substring(0,32);

        // minify data 
        string  minify = Newtonsoft.Json.JsonConvert.SerializeObject(payOutRequest);
        Console.WriteLine("minify:" + minify);

        string signContent = $"{timestamp}|{merchanteSerct}|{minify}";
        Console.WriteLine("request path:" + requestPath);

        var signature = SignatureUtils.sha256RsaSignature(signContent, Constant.privateKeyStr);
        using (HttpClient client = new HttpClient())
        {
            // request headers 
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("X-TIMESTAMP", timestamp);
            client.DefaultRequestHeaders.Add("X-SIGNATURE", signature);
            client.DefaultRequestHeaders.Add("X-PARTNER-ID", merchantId);
            StringContent content = new StringContent(minify, Encoding.UTF8, "application/json");

            Console.WriteLine("content:" + Newtonsoft.Json.JsonConvert.SerializeObject(content));

            // request post
            HttpResponseMessage response =
                await client.PostAsync(requestPath, content);

            // is success ?
            if (response.IsSuccessStatusCode)
            {
                // read response body 
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(responseBody);
            }
            else
            {
                // read response body 
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(responseBody);
            }
        }
    }
}
