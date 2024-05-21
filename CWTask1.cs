//Вариант 1
using System;

public struct Number
{
    private int realPart;

    public Number(int realPart)
    {
        this.realPart = realPart;
    }

    public static Number Add(Number num1, Number num2)
    {
        return new Number(num1.realPart + num2.realPart);
    }

    public static Number Subtract(Number num1, Number num2)
    {
        return new Number(num1.realPart - num2.realPart);
    }

    public static Number Multiply(Number num1, Number num2)
    {
        return new Number(num1.realPart * num2.realPart);
    }

    public static Number Divide(Number num1, Number num2)
    {
        return new Number(num1.realPart / num2.realPart);
    }

    public void PrintNumber()
    {
        Console.WriteLine("Number = " + realPart);
    }
}

class Program
{
    static void Main()
    {
        Number num1 = new Number(5);
        Number num2 = new Number(8);

        Number sum = Number.Add(num1, num2);
        Number diff = Number.Subtract(num1, num2);
        Number product = Number.Multiply(num1, num2);
        Number quotient = Number.Divide(num1, num2);

        num1.PrintNumber();
        num2.PrintNumber();
        sum.PrintNumber();
        diff.PrintNumber();
        product.PrintNumber();
        quotient.PrintNumber();
    }
}