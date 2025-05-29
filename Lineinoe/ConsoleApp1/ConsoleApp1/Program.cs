namespace ConsoleApp1; //Перезагрузка методов
class Geometry
{
    public double Volume(double a) // Куб
    {
        return Math.Pow(a, 3);
    }

    public double Volume(double a, double b, double c) // Прямоугольный параллелепипед
    {
        return a * b * c;
    }

    public double Volume(double r, double h, bool isCylinder) // Цилиндр
    {
        return Math.PI * r * r * h;
    }

    public double VolumeSphere(double r) // Шар
    {
        return (4.0 / 3) * Math.PI * Math.Pow(r, 3);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Geometry g = new Geometry();

        Console.WriteLine("Объем куба со стороной 2 равен " + g.Volume(2));
        Console.WriteLine("Объем параллелепипеда 2x3x4 равен " + g.Volume(2, 3, 4));
        Console.WriteLine("Объем цилиндра с радиусом 3 и высотой 5 равен " + Math.Round(g.Volume(3, 5, true), 2));
        Console.WriteLine("Объем шара с радиусом 3 равен " + Math.Round(g.VolumeSphere(3), 2));
    }
}
