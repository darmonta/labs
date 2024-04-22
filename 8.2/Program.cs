using System;
using System.Runtime.ConstrainedExecution;

public class Goods
{
    public string Name;
    public DateTime Date;
    public double Price;
    public double Quantity;
    public string InvoiceNumber;

    public void Print()
    {
        Console.WriteLine($"Название: {Name} \nДата оформления: {Date} \nЦена: {Price} \nКоличество {Quantity} \nНомер накладной {InvoiceNumber} \n{ToString()}");
    }

    // Метод для увеличения количества товара
    public void IncreaseQuantity(double quantityToAdd)
    {
        Quantity += quantityToAdd;
    }

    // Метод для уменьшения количества товара
    public void DecreaseQuantity(double quantityToRemove)
    {
        Quantity -= quantityToRemove;
    }

    // Метод для изменения цены товара
    public void ChangePrice(double newPrice)
    {
        Price = newPrice;
    }

    // Метод для вычисления стоимости товара
    public double CalculateCost()
    {
        return Price * Quantity;
    }

    // Метод для отображения стоимости товара в виде строки
    public override string ToString()
    {
        return $"Стоимость товара: {CalculateCost():F2} рублей";
    }
}

// Пример использования класса Goods
class Program
{
    static void Main()
    {
        static Goods Good()
        {
            var good = new Goods();
            good.Name = "Яблоко";
            good.Date = DateTime.Now;
            good.Price = 100;
            good.Quantity = 10;
            good.InvoiceNumber = "001";
            return good;
        }
        
        //Вывод информации о товаре
        var good = Good();
        good.Print();

        //Изменение цены товара
        a3:
        Console.Write("Введите новую стоимость: ");
        string a = Console.ReadLine();
        if (!double.TryParse(a, out double newprice) || (newprice<0))
        { 
            Console.WriteLine("Некорректное значение!");
            goto a3;
        }
        else
        {
            good.ChangePrice(newprice);
        }

    //Изменение количества товара
        a1:
        Console.WriteLine("Вы хотите 1) увеличить кол-во товара 2) уменьшить кол-во товара");
        string b = Console.ReadLine();
        if ((int.TryParse(b, out int num)) && ((num == 1) | (num == 2)))
        {
            a2:
            Console.WriteLine("Введите ч-ло, на которое будет изменяться товар");
            string c = Console.ReadLine();
            if (double.TryParse(c, out double number))
            {
                if (num == 1)
                {
                    good.IncreaseQuantity(number);
                    good.Print();
                }
                else
                {
                    if (number > good.Quantity)
                    {
                        Console.WriteLine("Количество товара не может быть отрицательным");
                        goto a2;
                    }
                    else
                    {
                        good.DecreaseQuantity(number);
                        good.Print();
                    }    
                }
            }
            else { Console.WriteLine("Некорректное значение!"); goto a2; }
        }
        else { Console.WriteLine("Некорректное значение!"); goto a1; }
    }
}