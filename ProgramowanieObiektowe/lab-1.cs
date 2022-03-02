using System;

public enum Currency
{
    PLN = 1,
    USD = 2,
    RUB = 3
}

public class Money: IEquatable<Money>
{
    private readonly decimal _value;
    private readonly Currency _currency;
    private Money (decimal value, Currency currency)
    {
        _value = value;
        _currency = currency;
    }
}
public static Money? Of(decimal value, Money money)
{
    return value < 0; 
}


