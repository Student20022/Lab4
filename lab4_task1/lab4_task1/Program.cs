using System;

// Клас "пряма на площині"
class TLine2D
{
    private double a; // Коефіцієнт 'a' канонічного рівняння
    private double b; // Коефіцієнт 'b' канонічного рівняння
    private double c; // Коефіцієнт 'c' канонічного рівняння

    // Конструктор без параметрів
    public TLine2D()
    {
        a = 0;
        b = 0;
        c = 0;
    }

    // Конструктор з параметрами
    public TLine2D(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // Конструктор копіювання
    public TLine2D(TLine2D otherLine)
    {
        this.a = otherLine.a;
        this.b = otherLine.b;
        this.c = otherLine.c;
    }

    // Введення даних
    public void Input()
    {
        Console.Write("Введіть коефіцієнт 'a': ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Введіть коефіцієнт 'b': ");
        b = double.Parse(Console.ReadLine());
        Console.Write("Введіть коефіцієнт 'c': ");
        c = double.Parse(Console.ReadLine());
    }

    // Виведення даних
    public void Display()
    {
        Console.WriteLine($"Рівняння прямої: {a}x + {b}y + {c} = 0");
    }

    // Знаходження точки перетину з іншою прямою
    public bool IntersectsWith(TLine2D otherLine, out double x, out double y)
    {
        x = 0;
        y = 0;

        double determinant = a * otherLine.b - otherLine.a * b;

        if (determinant == 0)
        {
            // Прямі паралельні або співпадають
            return false;
        }
        else
        {
            x = (otherLine.c * b - c * otherLine.b) / determinant;
            y = (a * otherLine.c - otherLine.a * c) / determinant;
            return true;
        }
    }

    // Визначення належності точки прямій
    public bool ContainsPoint(double x, double y)
    {
        return a * x + b * y + c == 0;
    }

    // Перевантаження операторів
    public static TLine2D operator +(TLine2D line1, TLine2D line2)
    {
        return new TLine2D(line1.a + line2.a, line1.b + line2.b, line1.c + line2.c);
    }

    public static TLine2D operator -(TLine2D line1, TLine2D line2)
    {
        return new TLine2D(line1.a - line2.a, line1.b - line2.b, line1.c - line2.c);
    }
}

// Клас-нащадок для прямої в просторі
class TLine3D : TLine2D
{
    private double d; // Коефіцієнт 'd' канонічного рівняння

    // Конструктор без параметрів
    public TLine3D()
    {
        d = 0;
    }

    // Конструктор з параметрами
    public TLine3D(double a, double b, double c, double d) : base(a, b, c)
    {
        this.d = d;
    }

    // Конструктор копіювання
    public TLine3D(TLine3D otherLine) : base(otherLine)
    {
        this.d = otherLine.d;
    }

    // Введення даних
    public new void Input()
    {
        base.Input(); // Виклик методу базового класу
        Console.Write("Введіть коефіцієнт 'd': ");
        d = double.Parse(Console.ReadLine());
    }

    // Виведення даних
    public new void Display()
    {
        base.Display(); // Виклик методу базового класу
        Console.WriteLine($"Коефіцієнт 'd': {d}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TLine2D line1 = new TLine2D(2, -3, 4);
        TLine2D line2 = new TLine2D(1, 1, -5);

        TLine2D line3 = line1 + line2;
        TLine2D line4 = line1 - line2;

        line1.Display();
        line2.Display();
        line3.Display();
        line4.Display();

        TLine3D line3D = new TLine3D(2, -3, 4, 1);
        line3D.Display();
    }
}
