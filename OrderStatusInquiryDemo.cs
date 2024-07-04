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
        inquiryRequest.tradeType = "1";
        // inquiryRequest.tradeNo = "T111200302403131706568283";
        inquiryRequest.orderNo = "T117200302403131706567635";

        // 准备要发送的数据
        string  minify = Newtonsoft.Json.JsonConvert.SerializeObject(inquiryRequest);
        Console.WriteLine("minify:" + minify);

        string signContent = $"{timestamp}|{merchanteSerct}|{minify}";
        Console.WriteLine("request path:" + requestPath);

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