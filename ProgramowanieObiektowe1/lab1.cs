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
        if (value < 0)
        {
            throw new Exception("Error value<0");
        }

        return new Money(value, currency);
    }

    public static Money ParseValue(string stringValue, Currency currency)
    {
        decimal value = decimal.Parse(stringValue);
        return new Money(value, currency);
    }

    public bool Equals(Money? other)
    {
        throw new NotImplementedException();
    }

    public Currency Currency
    {
        get { return _currency; }
    }
    public decimal Value
    {
        get { return _value; }
    }
    public static Money operator *(Money money, decimal factor)
    {
        return new Money(money.Value * factor, money.Currency);
    }
    public static Money operator +(Money moneya, Money moneyb)
    {
        if (moneya.Currency != moneyb.Currency) throw new Exception("Error Currencies not matching");
        return new Money(moneya.Value + moneyb.Value, moneya.Currency);
    }
    public static bool operator <(Money moneya, Money moneyb)
    {
        if (moneya.Currency != moneyb.Currency) throw new Exception("Error Currencies not matching");
        return (moneya.Value < moneyb.Value);
    }
    public static bool operator >(Money moneya, Money moneyb)
    {
        if (moneya.Currency != moneyb.Currency) throw new Exception("Error Currencies not matching");
        return (moneya.Value > moneyb.Value);
    }
    public static explicit operator float(Money money)
    {
        return (float)money.Value;
    }

}
public class Tank
{
    public readonly int Capacity;
    private int _level;
    public Tank(int capacity)
    {
        Capacity = capacity;
    }
    public int Level
    {
        get { return _level; }
        set
        {
            if (value < 0 || value > Capacity) throw new ArgumentOutOfRangeException();
            _level = value;
        }
    }
    public bool Consume(int w)
    {
        if (w > _level)
        {
            return false;
        }
        Level = _level - w;
        return true;
    }
    public void Refuel(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Argument cant be non positive!");
        }
        if (_level + amount > Capacity)
        {
            throw new ArgumentException("Argument is to large!");
        }
        _level += amount;
    }
    public bool Refuel(Tank sourceTank, int amount)
    {
        if (this.Level + amount > Capacity)
        {
            return false;
        }
        if (sourceTank.Consume(amount))
        {
            this.Refuel(amount);
            return true;
        }

        return false;
    }

}
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}


