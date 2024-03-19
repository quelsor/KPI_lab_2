/*Скласти опис класу прямокутників зі сторонами, паралельними осям координат. Передбачити можливість переміщення прямокутників на площині, зміна розмірів, 
 * побудова найменшого прямокутника, що містить два заданих прямокутники, і прямокутника, що є спільною частиною (перетином) двох прямокутників.*/

using System.Drawing;
using System.Text.Json;

class Program
{
    static void Main()
    {

        Rectangle rect1 = new Rectangle(1, 2);
        Rectangle rect2 = new Rectangle(3, 4);
        Rectangle rect3 = new Rectangle(3, 4);

        Console.WriteLine("Program:");
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("Output Information:\n");
        
        rect1.Print();
        rect2.Print();

        Console.WriteLine("\nChange Coordinates:\n");

        rect1.Coordinates(0, 4, 3, 0);
        rect1.Print();

        Console.WriteLine("\nChange Size:\n");

        rect2.Resize(5, 1);
        rect2.Print();

        Console.WriteLine("\nCreate the Smallest Rectangle from Two:\n");

        rect3.Combine(rect1, rect2);
        rect3.Print();

        Console.WriteLine("\nCreate the Intersect Rectangle from Two:\n");

        rect3.Intersect(rect1, rect2);
        rect3.Print();

        Console.WriteLine("\nWe Can Cath Errors:\n");

        rect3.Resize(-5, 8);
        rect3.Print();
        rect1.Coordinates(3, 0, 1, 2);
        rect1.Print();
        rect1.Intersect(rect2, rect3);

        Deserialize(Serialize());

        string Serialize()
        {

            Console.WriteLine("\nJSON File:\n");

            Rectangle rect4 = new Rectangle(3, 4);

            string json = JsonSerializer.Serialize(rect4);
            string filePath = "rect.json";
            File.WriteAllText(filePath, json);
            string reader = File.ReadAllText(filePath);

            Console.WriteLine(reader);

            string currentDirectory = Path.GetFullPath(filePath);
            Console.WriteLine("\n File location:\n" + currentDirectory);

            return filePath;
        }

        void Deserialize(string filePath)
        {
            string reader = File.ReadAllText(filePath);
            Rectangle deserializedRect = JsonSerializer.Deserialize<Rectangle>(reader);
            Console.WriteLine($"\nLength: {deserializedRect.length}, Width: {deserializedRect.width}");
        }
    }
}

