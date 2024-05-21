
//Вариант 7
using System;

public class Number
{
    private int realPart;
    private int imaginaryPart;
    public Number(int realPart, int imaginaryPart)
    {
        this.realPart = realPart;
        this.imaginaryPart = imaginaryPart;
    }
    public static ComplexNumber Add(ComplexNumber num1, ComplexNumber num2)
    {
        return new ComplexNumber(num1.realPart + num2.realPart, num1.imaginaryPart + num2.imaginaryPart);
    }
    public static ComplexNumber Subtract(ComplexNumber num1, ComplexNumber num2)
    {
        return new ComplexNumber(num1.realPart - num2.realPart, num1.imaginaryPart - num2.imaginaryPart);
    }
    public static ComplexNumber Multiply(ComplexNumber num1, ComplexNumber num2)
    {
        int real = num1.realPart * num2.realPart - num1.imaginaryPart * num2.imaginaryPart;
        int imaginary = num1.realPart * num2.imaginaryPart + num1.imaginaryPart * num2.realPart;
        return new ComplexNumber(real, imaginary);
    }
    public static ComplexNumber Divide(ComplexNumber num1, ComplexNumber num2)
    {
        int denominator = num2.realPart * num2.realPart + num2.imaginaryPart * num2.imaginaryPart;
        int real = (num1.realPart * num2.realPart + num1.imaginaryPart * num2.imaginaryPart) / denominator;
        int imaginary = (num1.imaginaryPart * num2.realPart - num1.realPart * num2.imaginaryPart) / denominator;
        return new ComplexNumber(real, imaginary);
    }
    public void PrintComplexNumber()
    {
        Console.WriteLine("Number = " + realPart + (imaginaryPart >= 0 ? " + " : " - ") + Math.Abs(imaginaryPart) + "i");
    }
}
public class ComplexNumber : Number
{
    private int imaginaryPart;

    public ComplexNumber(int realPart, int imaginaryPart) : base(realPart, imaginaryPart)
    {
        this.imaginaryPart = imaginaryPart;
    }
}

class Program
{
    static void Main()
    {
        ComplexNumber num1 = new ComplexNumber(5, 2);
        ComplexNumber num2 = new ComplexNumber(3, -1);

        ComplexNumber sum = ComplexNumber.Add(num1, num2);
        ComplexNumber diff = ComplexNumber.Subtract(num1, num2);
        ComplexNumber product = ComplexNumber.Multiply(num1, num2);
        ComplexNumber quotient = ComplexNumber.Divide(num1, num2);

        num1.PrintComplexNumber();
        num2.PrintComplexNumber();
        sum.PrintComplexNumber();
        diff.PrintComplexNumber();
        product.PrintComplexNumber();
        quotient.PrintComplexNumber();
    }
}