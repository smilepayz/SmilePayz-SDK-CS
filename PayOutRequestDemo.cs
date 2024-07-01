using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gatewatApi;

public class PayOutRequestDemo
{
    static async Task Main()
    {
        string privateKeyStr = "MIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC3LbmfPhjGXJ+a6NVKyRWEfCpsKfl9UFnMRltNosJv+7qd6OUK3t7Q8fKX8rxuJBeXLLWrOZvjoGlP3ybvvhUSGKH+BLcN1k2eJbcKuThvXvKQvd7pXolY91gkF8V78FX+TKegZupbeji0XUGXCBNyShocYM6Cvailf0Iyv49dcktJmi4drBKfgj5l4HUY9TaDuCZOrhvFZfZZxBK1zkm72k0ZLfqTGmG8O2tsByndCTH2aPLT9odR8/O4qfoTG+vV9HivIKKOI2h0kZfQBOqWD4/ofwu9PNoRRzGgzfRpF3GhnKa3bRVSpCUuBtHfotQfFxbjaDk0s3K5BhQE7HxzAgMBAAECggEARHhaBxUeC595pVzcxVyOp3wGG3JBKL9NIZc277kj9tngcsAoRTzziqS1qmh4WK8zBjYXHg6ln5tJYiqmkjy6AY6llp7KkeiGENRGLEL5vl9+Se4/EXpd2pxyHOOp1N8MNccPbVyqw1DXO0wUhVDme/UI94yUBLjB/kKoSvHhs+qwJ8cz9C8sF3Zs/zF6Te/f+Z+HrIbVj4vlx6DYBs3pWe7J+XYg3XXpbvIBJVTN0lreQAjtopic0F7o1EULnllJmOqy+kiRMuSi5ESrWFOnuCrY0iz/C8LJKlqWa3d+1jVLPvKYucXvddYrwjyu8kYHZAenKWKkLPlQkQxGUFcX8QKBgQDYSCsgg7tDlXTw1P9Z2BhkVo1ugYWA1FcxqTY2sTOMOwCTt3QZAFEqofbNvdjZbk7vu8gh5LyxbWAr/sNqOXH5915a6DZKBGl+qBTH2TZZKmhCUWlmn8T7ySYclfsgIZsUxHaDfY+otiXGtNegSX9US9/AFVSMdiQBCmr5/i48mQKBgQDY0U5+MDl6GnbDH/hCT+YMq/m5W58m7ehJfG6jPtLQkPPvMq2Oj5HUeXx4vDdUxzaRlC9fICwe2KgKiGYpJsRPte6JfO6te7wsO2lDk0oBiw+jewm4CwZ5KeDYyReha8Hc2H1j5hllVx5DIZiage2ZswS5+kCNgzf4QbdAOd886wKBgAo5TyCYWY/WTtLbnr6GgpCrrr/ci40NfJmyYAex1Lf6Sgqxj2FnLG8RfPM42DlfB4g5njpL78eLXhJ2VpJ86LBiSymM9JQHJV2BYIoZ8IHCiW8pHgxl3Q/x8EVFqbtZG1Wd++Q3WUUmZx6/ibnf/47ij08rMvX417bc4TW0GEdxAoGAPX3nUBynQH0e76oyg8QbT766nZphoe3ZcnYK/tuDeMmTlWR/Gq6XQnaOGcPvwWiajmFDqiv6t2jlB8+1gbhP9vd3RqEbJDKypKzY5uRwGc3xyoDLudnOpTB+Z51oyUxBeDwiG+IXk8lIeOufVzrAQ1YlYgWap0fu6MbijSGcsa8CgYEA0OolBxRKdBSxmwMbXDocg5HtHd15UgJdlgL9GFjDZPisUvM7LWK97E5QPhY2IEIcv0EW9jM62bc1uPMhwDuN1dzmLafQIivGsIj5qUy18CoE4KJHsTeKLeHkrd6/nBd4da4A37+ksJ1t/sgZpjl40ShrxTV+OtzzY/kuQ4Uqc9g=";
        string publicKeyStr = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAty25nz4YxlyfmujVSskVhHwqbCn5fVBZzEZbTaLCb/u6nejlCt7e0PHyl/K8biQXlyy1qzmb46BpT98m774VEhih/gS3DdZNniW3Crk4b17ykL3e6V6JWPdYJBfFe/BV/kynoGbqW3o4tF1BlwgTckoaHGDOgr2opX9CMr+PXXJLSZouHawSn4I+ZeB1GPU2g7gmTq4bxWX2WcQStc5Ju9pNGS36kxphvDtrbAcp3Qkx9mjy0/aHUfPzuKn6Exvr1fR4ryCijiNodJGX0ATqlg+P6H8LvTzaEUcxoM30aRdxoZymt20VUqQlLgbR36LUHxcW42g5NLNyuQYUBOx8cwIDAQAB";
        string sandboxMerchanteCode = "6a58a603e5043290f4097ee4a7745661b3656932d4eebc3106b5dddc3af6e053";
        string merchanteCode = "95b57c46b8c2e068982be23fb669a80612cad68e6ce6ba4f5af9ec20d23bb274";
        string sandboxMerchanteId = "sandbox-20019";
        string merchanteId = "20019";
        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        MoneyRequest moneyRequest = new MoneyRequest();
        moneyRequest.amount = 200;
        moneyRequest.currency = CurrencyEnum.INR.ToString();

        MerchantRequest merchantRequest = new MerchantRequest();
        merchantRequest.merchantId = merchanteId;
        
        TradeAdditionalReq additionalReq = new TradeAdditionalReq();
        additionalReq.ifscCode = "YESB0000097";
        
        TradePayOutRequest payOutRequest = new TradePayOutRequest();
        payOutRequest.cashAccount = "17385238451";
        payOutRequest.merchant = merchantRequest;
        payOutRequest.money = moneyRequest;
        payOutRequest.paymentMethod = "YES";
        payOutRequest.area = AreaEnum.INDIA.Code;
        payOutRequest.purpose = "for test";
        payOutRequest.additionalParam = additionalReq;
        payOutRequest.orderNo = Guid.NewGuid().ToString("N");
        string referenceId = Guid.NewGuid().ToString("N");



        string payinPathUrl = "https://gateway.smilepayz.com/v2.0/disbursement/pay-out";
        string payinPathTestUrl = "https://sandbox-gateway.smilepayz.com/v2.0/disbursement/pay-out";
        // 准备要发送的数据
        string  minify = Newtonsoft.Json.JsonConvert.SerializeObject(payOutRequest);
        Console.WriteLine("minify:" + minify);

        string signContent = $"{referenceId}|{timestamp}|{merchanteCode}|{minify}";

        var signature = SignatureUtils.sha256RsaSignature(signContent, privateKeyStr);
        using (HttpClient client = new HttpClient())
        {
            // 添加自定义标头
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("X-TIMESTAMP", timestamp);
            client.DefaultRequestHeaders.Add("X-SIGNATURE", signature);
            client.DefaultRequestHeaders.Add("REFERENCE-ID", referenceId);
            client.DefaultRequestHeaders.Add("X-PARTNER-ID", merchanteId);
            StringContent content = new StringContent(minify, Encoding.UTF8, "application/json");

            Console.WriteLine("content:" + Newtonsoft.Json.JsonConvert.SerializeObject(content));

            // 发起 POST 请求
            HttpResponseMessage response =
                await client.PostAsync(payinPathUrl, content);

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
