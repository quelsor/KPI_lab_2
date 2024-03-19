using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

class Rectangle
{
    public int length { get; set; }
    public int width { get; set; }
    private int topLeftEngle_X; //cooredinates
    private int topLeftEngle_Y;
    private int bottomRightEngle_X;
    private int bottomRightEngle_Y;

    public Rectangle() { }

    public Rectangle(int x, int y) 
    { 
        length = x; width = y; UpdateCoordinates(); 
    }

    public void Resize (int x, int y)
    {
        length = x;
        width = y;
        UpdateCoordinates();
    }

    private void UpdateCoordinates()
    {
        bottomRightEngle_X = topLeftEngle_X + length;
        bottomRightEngle_Y = topLeftEngle_X;
        topLeftEngle_X = bottomRightEngle_X - length;
        topLeftEngle_Y = bottomRightEngle_Y + width;
    }

    private void UpdateSize()
    {
        length = Math.Abs(bottomRightEngle_X - topLeftEngle_X);
        width = Math.Abs(topLeftEngle_Y - bottomRightEngle_Y);
    }

    public void Coordinates(int topLeftEngle_X, int topLeftEngle_Y, int bottomRightEngle_X, int bottomRightEngle_Y)
    {
        this.topLeftEngle_X = topLeftEngle_X; 
        this.topLeftEngle_Y = topLeftEngle_Y;
        this.bottomRightEngle_X = bottomRightEngle_X;
        this.bottomRightEngle_Y = bottomRightEngle_Y;
        UpdateSize();
    }

    public void Move(int x)
    {
        topLeftEngle_X += x;
        topLeftEngle_Y += x;
        bottomRightEngle_X += x;
        bottomRightEngle_Y += x;
        UpdateSize();
    }

    public void MoveRight(int x)
    {
        topLeftEngle_X += x;
        bottomRightEngle_X += x;
        UpdateSize();
    }
    public void MoveUp(int x)
    {
        topLeftEngle_Y += x;
        bottomRightEngle_Y += x;
        UpdateSize();
    }

    public void Combine(Rectangle other1, Rectangle other2)
    {
        length =  Math.Max(other1.length, other2.length);
        width = Math.Max(other1.width, other2.width);
    }

    public void Intersect(Rectangle other1, Rectangle other2)
    {
        int newTopLeftX = Math.Max(other1.topLeftEngle_X, other2.topLeftEngle_X);
        int newTopLeftY = Math.Min(other1.topLeftEngle_Y, other2.topLeftEngle_Y);
        int newBottomRightX = Math.Min(other1.bottomRightEngle_X, other2.bottomRightEngle_X);
        int newBottomRightY = Math.Max(other1.bottomRightEngle_Y, other2.bottomRightEngle_Y);

        if (newTopLeftX < newBottomRightX && newTopLeftY > newBottomRightY)
        {
            topLeftEngle_X = newTopLeftX;
            topLeftEngle_Y = newTopLeftY;
            bottomRightEngle_X = newBottomRightX;
            bottomRightEngle_Y = newBottomRightY;
        }
        else
        {
            Console.WriteLine("Error: Rectangles do not intersect");
        }

        UpdateSize();
    }

    public void Print()
    {
        if ((length < 0 || width < 0) || (topLeftEngle_X >= bottomRightEngle_X || topLeftEngle_Y <= bottomRightEngle_Y))
        {
            Console.WriteLine("Error: You enter wrong parameters or coordinates");
        }
        else
        {
            Console.WriteLine($"Rectangle: length: {length}, width: {width}");
            Console.WriteLine($"Plase on coordinate system: top left engle: {topLeftEngle_X}, {topLeftEngle_Y} bottom right engle: {bottomRightEngle_X}, {bottomRightEngle_Y}");
        }
    }
}
