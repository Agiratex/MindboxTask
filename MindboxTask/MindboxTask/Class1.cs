using System;
namespace Figure;


public abstract class Figure
{
    public abstract double Area();
}



public class Circle : Figure
{
    public double rad { get; set; }

    public Circle(double rad)
    {
        if (rad < 0)
        {
            throw new ArgumentException("Invalid radius");
        }
        this.rad = rad;
    }

    public override double Area()
    {
        return Math.PI * rad * rad;
    }
}

public class Triangle : Figure
{
    private double _x;
    public double x
    {
        get
        {
            return _x;
        }
        set
        {
            if (CheckSides(value, _y, _z) | value < 0)
            {
                throw new ArgumentException("Invalid sizes for triangle");
            }
            _x = value;
        }
    }

    private double _y;
    public double y
    {
        get
        {
            return _y;
        }
        set
        {
            if (CheckSides(_x, value, _z) | value < 0)
            {
                throw new ArgumentException("Invalid sizes for triangle");
            }
            _y = value;
        }
    }

    private double _z;
    public double z
    {
        get
        {
            return _z;
        }
        set
        {
            if (CheckSides(_x, _y, value) | value < 0)
            {
                throw new ArgumentException("Invalid sizes for triangle");
            }
            _z = value;
        }
    }
    public Triangle(double x = 0, double y = 0, double z = 0)
    {
        if (CheckSides(x, y, z))
        {
            throw new ArgumentException("Invalid sizes for triangle");
        }
        if ((_x < 0) | (_y < 0) | (_z < 0))
        {
            throw new ArgumentException("Invalid sizes for triangle");
        }
        this._x = x;
        this._y = y;
        this._z = z;
    }

    public override double Area()
    {
        double p = (_x + _y + _z) / 2;
        return Math.Sqrt(p * (p - _x) * (p - _y) * (p - _z));
    }

    private bool CheckSides(double x, double y, double z)
    {
        return ((x + y < z) | (x + z < y) | (y + z < x));
    }


    //Прямоугольный тругольник упрощает получение площади (как произведение катетов).
    //Это сократит количество операция для таких треугольников. Но в общем случае замеляет.
    //Поэтому я решил не использовать проверку для подсчета площади
    public bool IsRight { get
        {
            double max;
            double a, b;
            if (x > y)
            {
                max = x;
                a = y;
            } else
            {
                max = y;
                a = x;
            }
            if (max < z)
            {
                max = z;
                a = x;
                b = y;
            }
            else
            {
                b = z;
            }
            return (Math.Abs(max * max - a * a - b * b) < 0.0001);
        }
    }
}

public class Calc
{
    public static double Area(Figure fig)
    {
        return fig.Area();
    }
}