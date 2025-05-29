using MyApp.Models;
namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            // Метод для установки значений
            car.SetMakeAndModel("Toyota", "Corolla");
            car.Year = 2015;

            // Вызываем отображение информации
            car.ShowInfo();

            Console.WriteLine();

            // Создание электромобиля
            ElectricCar tesla = new ElectricCar();

            // Устанавливаем данные через доступные методы
            tesla.SetMakeAndModel("Tesla", "Model S");
            tesla.Year = 2022;
            tesla.SetBatteryCapacity(100.5);

            // Вывод информации об электромобиле
            tesla.ShowInfo();
        }
    }
}