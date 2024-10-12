using System.Text;

namespace gatewatApi;

public class OrderStatusInquiryDemo
{
     public static async Task InquiryDemo()
    {
        // sandbox 
        string requestPath =Constant.baseUrlSanbox + "/v2.0/inquiry-status";
        string merchantId = Constant.merchantIdSandBox;
        string merchanteSerct = Constant.merchantSecretSandBox;
        
        // prdoction
        // string requestPath = Constant.baseUrl +"/v2.0/inquiry-status";
        // string merchantId = Constant.merchantId;
        // string merchanteSerct = Constant.merchantSecret;
        
        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        OrderStatusInquiryRequest inquiryRequest = new OrderStatusInquiryRequest();
        inquiryRequest.tradeType = Constant.tradeTypePayIn;
        inquiryRequest.tradeNo = "platform trade no";
        inquiryRequest.orderNo = "merchant order no";

        // minify data
        string  minify = Newtonsoft.Json.JsonConvert.SerializeObject(inquiryRequest);
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

            //send post request
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