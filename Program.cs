// See https://aka.ms/new-console-template for more information
using System;
using gatewatApi;

class Program
{
    static async Task Main(string[] args)
    {
        // await PayInRequestDemo.PayInDemo();
        // await BalanceInquiryDemo.InquiryDemo();
        await OrderStatusInquiryDemo.InquiryDemo();
        // await PayOutRequestDemo.PayOutDemo();
        // SignatureUtils.SignatureDemo();
    }
}
