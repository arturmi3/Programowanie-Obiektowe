using System;

public enum Currency
{
    PLN = 1,
    USD = 2,
    RUB = 3
}

public class Money : IEquatable<Money>
{
    private readonly decimal _value;
    private readonly Currency _currency;
    private Money(decimal value, Currency currency)
    {
        _value = value;
        _currency = currency;
    }

    public static Money OfWithException(decimal value, Currency currency)
    {
        if (value<0) 
        {
            throw new Exception("Error value<0");
        }
        else new Money (value,currency)
    }
    
    public static Money ParseValue(string stringValue, Currency currency)
    {
        decimal value = decimal.Parse(stringValue);
        return new Money(stringValue, currency);
    }


