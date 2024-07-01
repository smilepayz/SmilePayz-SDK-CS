// See https://aka.ms/new-console-template for more information
using System;
using gatewatApi;

class Program
{
    static void Main1()
    {
        // Replace with the actual public-private key pair
        string privateKeyStr = "MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDcNJSb8ATHw9WhujslPeFbUj9kej95dMeXV96jUdnyRHc6kOVAk46D8CHWxP/69dmMkK7AsmSgtuxNzmPuiFQ4xXeJsiUIFhzGwvRQ/YGMN0eGxlU1YMsZ2KU1I7iP+YXXgNpF+VWJEt0pGdrYYv6kPyB8XKoUWEQMLe5ctmvdwnSJnwOFDVbFjhJ3gS8+xe6NUnG0eUKy7iMacig1XFSuKFt+ToYOttJR2CFLvtwI4Ccaaj00wBTgR6o8p9i7Vesp5a3tcL6sJeFYHxxC3QfhVz08hTO0mHx+RfU+R0JH1Yk/mKVOqJGPEUTquKZfjYft2Y8WJOLl3zrZm1lwgNcpAgMBAAECggEAGa8z3L7pjdPmo30leC3wLs7IeFumcvAXNizAeg/6Yf7QodcD+GzlmPfNuJ9khKT/pZy8F1uPb2v6osYlo41I9pC4xUmvNlLe8yOK6/XvsfdCK2MPjgDu26JIfcrfdIKcFQNxYitHiewWefxrKWVdknKPA1ZrG6GieUGzvWJlMTmtWXsBxEfQGXhN6MH7oInQvkTB6raXd9MQeSQrqcXLkhYt8hfctaCat/YeZy8ulGeQE+TCzpPkuZBHNHXb90I6DCyPSr5u1vI6zu7GW0AroBcdCoSGmzrBPOJfKyUgHTGa00JoYfpJsGcrCKE0Jpdq+xAYzPTBHY2u3jD2dVtzgQKBgQDh3Mb2AqqyMT8tG4mPQCPsbkC762TCkPu/IcoqbTofr8kuR6eTGxcgY6mMQk7MlURw+Y2mSnvRKhws/RRXtbNbgLASO9asz74XC8Mez0sZumUqu8Z7o+2O/Spf3nL8Ftll8wfhz8zAYDLOl0Cye03cKcZj+To+aNpcDB6xV9GFgQKBgQD5lpDFFzLaUikmDRCXXbuwkAWTj1XGPffjvY8G7jm2tSnDdu8PIjbdWhQyX80CwHvCM/CDbfEVH+SOqueR6eUUDsfBJngrz6sq1M+FI3p1Rk4Rhv4nISuUbe90a3pcukb7knv8oxn38xCy8OEY1V9t7X2h/dLbs+LeR4iVFIw1qQKBgQCc4IwRM6j8O9h1rDrPlO1euvWbkNRbj/hLuVyCO3uzppVF3980/gwCIzcQhL3Wu5beIXeRmQqHLYiEdwQ6J6p8U9X31Dg3r9OIjlLog3LWW/EIzYP/PM00FAPqsseK8RPvC+7dmUfOFwMzGzuEvMBHu3xg1CrwTkPcy05GP4j4AQKBgCtnYLO1rhVDdn50hS8dkNdKpH2dzpfUDPjg7S+SXB0G8kVYuIgUNiBWWu7LtDZHTP5f0/K3OtamnjOlSvIYD8tmKpzPWNSdn7GqIpCPs+sTF956cFZTsWV1nM/NJRFdH5z+Q2uS3aA99+h2dV7BNIBEbbWvE207ojdvjzQFx8BJAoGBAMJt5DR0wrTstn4xqahLsXcp7IdhzVOmzw/BGKIXQXgbdBC/05i7+yw3HukvlGcvoMGUJ3Zuz+E3xD8ZIvXCPePrFJERpGyGxzBVl09voAxNmPFN8jKjgi2vY7ZD6b6KUV61YqaGk3XJmWDGRX6vfXz17ZY1wJOjd/4y+JonvD9y"; 
        string publicKeyStr = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA3DSUm/AEx8PVobo7JT3hW1I/ZHo/eXTHl1feo1HZ8kR3OpDlQJOOg/Ah1sT/+vXZjJCuwLJkoLbsTc5j7ohUOMV3ibIlCBYcxsL0UP2BjDdHhsZVNWDLGdilNSO4j/mF14DaRflViRLdKRna2GL+pD8gfFyqFFhEDC3uXLZr3cJ0iZ8DhQ1WxY4Sd4EvPsXujVJxtHlCsu4jGnIoNVxUrihbfk6GDrbSUdghS77cCOAnGmo9NMAU4EeqPKfYu1XrKeWt7XC+rCXhWB8cQt0H4Vc9PIUztJh8fkX1PkdCR9WJP5ilTqiRjxFE6rimX42H7dmPFiTi5d862ZtZcIDXKQIDAQAB";
        string stringToSign = "sandbox-20055|2024-06-25T17:32:38+00:00";
        
        string signature = SignatureUtils.sha256RsaSignature(stringToSign, privateKeyStr);
        if (signature != null)
        {
            Console.WriteLine("Signature: " + signature);
        }
        else
        {
            Console.WriteLine("Failed to create signature.");
        }
        var doCheck = SignatureUtils.checkSha256ResSiganture(stringToSign, signature, publicKeyStr, "UTF-8");
        Console.WriteLine("Check result: "+ doCheck);
    }
}
