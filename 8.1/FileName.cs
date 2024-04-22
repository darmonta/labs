using System;

public class Money
{
    public long rubles;
    public int kopecks;
    public double wholesum;

    public Money(long rubles, int kopecks)
    {
        this.rubles = rubles;
        this.kopecks = kopecks;
        wholesum = rubles + kopecks * 0.01;
    }

    public override string ToString()
    {
        // Форматирование вывода суммы с запятой в качестве разделителя тысяч
        return $"{wholesum}";
    }

    // Операция сложения
    public static void Sum(Money money1, Money money2)
    {
        Console.WriteLine($"сумма: {money2.wholesum + money1.wholesum}");
    }

    // Операция вычитания
    public static void Diff(Money money1, Money money2)
    {
        Console.WriteLine($"разность: {money1.wholesum - money2.wholesum}");
    }

    // Операция деления сумм
    public static void Div(Money money1, Money money2)
    {
        double a = money1.wholesum / money2.wholesum;
        Console.WriteLine($"частное: {a:F2}");
    }

    // Операция сравнения
    public static void Compare(Money money1, Money money2)
    {
        if (money1.wholesum < money2.wholesum)
        {
            Console.WriteLine("вторая сумма больше");
        }
        else if (money1.wholesum > money2.wholesum)
        {
            Console.WriteLine("первая сумма больше");
        }
        else
        {
            Console.WriteLine("суммы равны");
        }
    }

    //деление суммы на число
    public static void DivByNumber(Money money, double divisor)
    {
        double a = money.wholesum / divisor;
        Console.WriteLine($"деление суммы на число: {a:F2}");
    }

    //умножение суммы на число
    public static void Multiply(Money money, double multi)
    {
        double a = money.wholesum * multi;
        Console.WriteLine($"умножение суммы на число: {a:F2}");
    }

    // Метод для получения вещественного числа от пользователя
    public static double GetNumberFromUser()
    {
        a:
        Console.WriteLine("Введите вещественное число:");
        string doubleNumberInput = Console.ReadLine();
        if (!double.TryParse(doubleNumberInput, out double number))
        {
            Console.WriteLine("Введено некорректное значение.");
            goto a;
        }
        return number;
    }
}

class Program
{
    static void Main()
    {
        z:
        Console.Write("Введите количество рублей первой суммы: ");
        string rubles1Input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(rubles1Input))
        {
            Console.WriteLine("Вы не ввели количество рублей. Пожалуйста, введите что - то.");
            goto z;
        }
        if (!long.TryParse(rubles1Input, out long rubles1))
        {
            Console.WriteLine("Введено некорректное значение для количества рублей первой суммы.");
            goto z;
        }
        Console.Write("Введите количество копеек первой суммы: ");
        string kopecks1Input = Console.ReadLine();
        if (!int.TryParse(kopecks1Input, out int kopecks1))
        {
            Console.WriteLine("Введено некорректное значение для количества копеек первой суммы.");
            goto z;
        }
        w:
        Console.Write("Введите количество рублей второй суммы: ");
        string rubles2Input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(rubles2Input))
        {
            Console.WriteLine("Вы не ввели количество рублей. Пожалуйста, введите что - то.");
            goto w;
        }
        if (!long.TryParse(rubles2Input, out long rubles2))
        {
            Console.WriteLine("Введено некорректное значение для количества рублей второй суммы.");
            goto w;
        }
        Console.Write("Введите количество копеек второй суммы: ");
        string kopecks2Input = Console.ReadLine();
        if (!int.TryParse(kopecks2Input, out int kopecks2))
        {
            Console.WriteLine("Введено некорректное значение для количества копеек второй суммы.");
            goto w;
        }
       
        Money money1 = new Money(rubles1, kopecks1);
        Money money2 = new Money(rubles2, kopecks2);

        Console.WriteLine($"сумма 1: {money1}");
        Console.WriteLine($"сумма 2: {money2}");

        // Сложение
        Money.Sum(money1, money2);

        // Вычитание
        Money.Diff(money1, money2);

        // Деление сумм
        Money.Div(money1, money2);

        // Получаем делитель от пользователя
        double number1 = Money.GetNumberFromUser();
        Money.DivByNumber(money1, number1);

        double number2 = Money.GetNumberFromUser();
        Money.DivByNumber(money2, number2);

        //умножение на число
        Money.Multiply(money1, number1);

        Money.Multiply(money2, number2);

        //сравнение
        Money.Compare(money1, money2);  
    }
}