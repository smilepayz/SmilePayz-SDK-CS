namespace gatewatApi;
using System;
using System.Security.Cryptography;
using System.Text;

public class SignatureUtils
{
    public static string sha256RsaSignature(string stringToSign, string privateKeyStr)
    {
        try
        {
            byte[] privateKeys = Convert.FromBase64String(privateKeyStr);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportPkcs8PrivateKey(privateKeys, out _);

            byte[] dataToSign = Encoding.UTF8.GetBytes(stringToSign);
            byte[] signatureBytes = rsa.SignData(dataToSign, CryptoConfig.MapNameToOID("SHA256"));

            return Convert.ToBase64String(signatureBytes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    
    public static bool checkSha256ResSiganture(string content, string signed, string publicKeyStr, string encode)
    {
        try
        {
            byte[] publicKeys = Convert.FromBase64String(publicKeyStr);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportSubjectPublicKeyInfo(publicKeys, out _);

            byte[] dataToVerify = Encoding.GetEncoding(encode).GetBytes(content);
            byte[] signatureBytes = Convert.FromBase64String(signed);

            return rsa.VerifyData(dataToVerify, CryptoConfig.MapNameToOID("SHA256"), signatureBytes);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        return false;
    }
    
    
    /**
     * HmacSHA512 signature
     */
    public static string DoTransactionSign(string signData, string secret)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
        byte[] dataBytes = Encoding.UTF8.GetBytes(signData);

        using (var hmac = new HMACSHA512(keyBytes))
        {
            byte[] hashBytes = hmac.ComputeHash(dataBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
    
    public static Boolean CheckTransactionSign(string signData,string signature, string secret)
    {
        var doTransactionSign = DoTransactionSign(signData, secret);
        return doTransactionSign == signature;
    }
    
    
    public  static string  SHA256ByteToHex(string requestBody)
    {
        using (SHA256Managed sha256 = new SHA256Managed())
        {
            byte[] computeHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(requestBody));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in computeHash)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString().ToLower();
        }
    }
  
}