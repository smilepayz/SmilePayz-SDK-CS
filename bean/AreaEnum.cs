namespace gatewatApi;
using System;
public class AreaEnum
{
    public static readonly AreaEnum INDONESIA = new AreaEnum(10, CurrencyEnum.IDR, 62);
    public static readonly AreaEnum THAILAND = new AreaEnum(11, CurrencyEnum.THB, 66);
    public static readonly AreaEnum INDIA = new AreaEnum(12, CurrencyEnum.INR, 91);
    public static readonly AreaEnum BRAZIL = new AreaEnum(13, CurrencyEnum.BRL, 55);

    public int Code { get; }
    public CurrencyEnum Currency { get; }
    public int CountryId { get; }

    private AreaEnum(int code, CurrencyEnum currency, int countryId)
    {
        Code = code;
        Currency = currency;
        CountryId = countryId;
    }

    public static AreaEnum FromCode(int code)
    {
        switch (code)
        {
            case 10: return INDONESIA;
            case 11: return THAILAND;
            case 12: return INDIA;
            case 13: return BRAZIL;
            default: throw new ArgumentException("Invalid code");
        }
    }
}
