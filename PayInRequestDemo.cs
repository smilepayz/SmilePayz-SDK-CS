using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gatewatApi;

public class PayInRequestDemo
{
    
    public static async Task PayInDemo()
    {
        
        // sandbox 
        // string requestPath =Constant.baseUrlSanbox + "/v2.0/transaction/pay-in";
        // string merchantId = Constant.merchantIdSandBox;
        // string merchanteSerct = Constant.merchantSecretSandBox;
        
        // prdoction
        string requestPath = Constant.baseUrl +"/v2.0/transaction/pay-in";
        string merchantId = Constant.merchantId;
        string merchanteSerct = Constant.merchantSecret;
        
        
        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        MoneyRequest moneyRequest = new MoneyRequest();
        moneyRequest.amount = 10000;
        moneyRequest.currency = CurrencyEnum.IDR.ToString();

        MerchantRequest merchantRequest = new MerchantRequest();
        merchantRequest.merchantId = merchantId;

        PayInRequest payInRequest = new PayInRequest();
        payInRequest.merchant = merchantRequest;
        payInRequest.money = moneyRequest;
        payInRequest.paymentMethod = "W_DANA";
        payInRequest.area = AreaEnum.INDONESIA.Code;
        payInRequest.purpose = "for test";

        payInRequest.orderNo = Guid.NewGuid().ToString("N");
        
        Console.WriteLine("request path:" + requestPath);

        // 准备要发送的数据
        string  minify = Newtonsoft.Json.JsonConvert.SerializeObject(payInRequest);
        Console.WriteLine("minify:" + minify);

        string signContent = $"{timestamp}|{merchanteSerct}|{minify}";

        var signature = SignatureUtils.sha256RsaSignature(signContent, Constant.privateKeyStr);
        using (HttpClient client = new HttpClient())
        {
            // 添加自定义标头
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("X-TIMESTAMP", timestamp);
            client.DefaultRequestHeaders.Add("X-SIGNATURE", signature);
            client.DefaultRequestHeaders.Add("X-PARTNER-ID", merchantId);
            StringContent content = new StringContent(minify, Encoding.UTF8, "application/json");

            Console.WriteLine("content:" + Newtonsoft.Json.JsonConvert.SerializeObject(content));

            // 发起 POST 请求
            HttpResponseMessage response =
                await client.PostAsync(requestPath, content);

            // 检查响应是否成功
            if (response.IsSuccessStatusCode)
            {
                // 读取响应内容
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine("Failed to get response. Status code: " + response.StatusCode);
            }
        }
    }
}
