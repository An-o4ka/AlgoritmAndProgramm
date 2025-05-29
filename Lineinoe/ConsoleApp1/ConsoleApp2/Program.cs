namespace ConsoleApp2;
abstract class Shape
{
    public abstract double Volume();
}

class Cube : Shape
{
    public double A { get; set; }

    public Cube(double a)
    {
        A = a;
    }

    public override double Volume()
    {
        return Math.Pow(A, 3);
    }
}

class Parallelepiped : Shape
{
    public double A, B, C;

    public Parallelepiped(double a, double b, double c)
    {
        A = a; B = b; C = c;
    }

    public override double Volume()
    {
        return A * B * C;
    }
}

class Cylinder : Shape
{
    public double R, H;

    public Cylinder(double r, double h)
    {
        R = r; H = h;
    }

    public override double Volume()
    {
        return Math.PI * R * R * H;
    }
}

class Sphere : Shape
{
    public double R;

    public Sphere(double r)
    {
        R = r;
    }

    public override double Volume()
    {
        return (4.0 / 3) * Math.PI * Math.Pow(R, 3);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[]
        {
            new Cube(2),
            new Parallelepiped(2, 3, 4),
            new Cylinder(3, 5),
            new Sphere(3)
        };

        Console.WriteLine("Объем куба со стороной 2 равен " + shapes[0].Volume());
        Console.WriteLine("Объем параллелепипеда 2x3x4 равен " + shapes[1].Volume());
        Console.WriteLine("Объем цилиндра с радиусом 3 и высотой 5 равен " + Math.Round(shapes[2].Volume(), 2));
        Console.WriteLine("Объем шара с радиусом 3 равен " + Math.Round(shapes[3].Volume(), 2));
    }
}