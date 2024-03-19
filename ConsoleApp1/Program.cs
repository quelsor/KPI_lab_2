using System;

class Rectangle
{
    private double length;
    private double width;

    // Конструктор без параметрів
    public Rectangle()
    {
        length = 0;
        width = 0;
    }

    // Конструктор з параметрами
    public Rectangle(double length, double width)
    {
        if (length <= 0 || width <= 0)
        {
            throw new ArgExp("Довжина та ширина повинні бути більше нуля.");
        }

        this.length = length;
        this.width = width;
    }

    // Властивості
    public double Length
    {
        get { return length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgExp("Довжина повинна бути більше нуля.");
            }
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgExp("Ширина повинна бути більше нуля.");
            }
            width = value;
        }
    }

    // Метод для зміни розмірів прямокутника
    public void Resize(double newLength, double newWidth)
    {
        if (newLength <= 0 || newWidth <= 0)
        {
            throw new ArgExp("Нова довжина та ширина повинні бути більше нуля.");
        }

        length = newLength;
        width = newWidth;
    }

    // Метод для побудови найменшого прямокутника, що містить два задані прямокутники
    public static Rectangle Combine(Rectangle rectangle1, Rectangle rectangle2)
    {
        double combinedLength = Math.Max(rectangle1.Length, rectangle2.Length);
        double combinedWidth = Math.Max(rectangle1.Width, rectangle2.Width);
        return new Rectangle(combinedLength, combinedWidth);
        return null;
    }

    // Метод для знаходження общої частини (перетину) двох прямокутників
    public static Rectangle Intersect(Rectangle rectangle1, Rectangle rectangle2)
    {
        double intersectLength = Math.Min(rectangle1.Length, rectangle2.Length);
        double intersectWidth = Math.Min(rectangle1.Width, rectangle2.Width);
        return new Rectangle(intersectLength, intersectWidth);
        return null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Демонстрація всіх розроблених елементів класу
            Rectangle rect1 = new Rectangle(5, 10);
            Rectangle rect2 = new Rectangle(8, 6);

            Console.WriteLine("Довжина прямокутника 1: " + rect1.Length);
            Console.WriteLine("Ширина прямокутника 1: " + rect1.Width);

            Console.WriteLine("Довжина прямокутника 2: " + rect2.Length);
            Console.WriteLine("Ширина прямокутника 2: " + rect2.Width);

            Rectangle combinedRect = Rectangle.Combine(rect1, rect2);
            Console.WriteLine("Найменший прямокутник, що містить обидва прямокутники: ");
            Console.WriteLine("Довжина: " + combinedRect.Length);
            Console.WriteLine("Ширина: " + combinedRect.Width);

            Rectangle intersectedRect = Rectangle.Intersect(rect1, rect2);
            Console.WriteLine("Обща частина (перетин) двох прямокутників: ");
            Console.WriteLine("Довжина: " + intersectedRect.Length);
            Console.WriteLine("Ширина: " + intersectedRect.Width);

            rect2.Resize(12, 8);
            Console.WriteLine("Після зміни розмірів прямокутника 2:");
            Console.WriteLine("Нова довжина: " + rect2.Length);
            Console.WriteLine("Нова ширина: " + rect2.Width);
        }
        catch (ArgExp ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}