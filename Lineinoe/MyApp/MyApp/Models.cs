namespace MyApp.Models
{
    // Базовый класс Car описывающий обычный автомобиль.
    public class Car
    {
        // Поле make: марка автомобиля (доступно только внутри класса)
        private string make;

        // Поле model: модель автомобиля (доступно только внутри класса)
        private string model;

        // Свойство Year: год выпуска автомобиля (доступно из любой части программы)
        public int Year { get; set; }
        
        // Метод SetMakeAndModel позволяет установить марку и модель автомобиля.
        // Модификатор internal — доступен внутри одной сборки (проекта).
        internal void SetMakeAndModel(string make, string model)
        {
            this.make = make;
            this.model = model;
        }
        
        // Метод DisplayInfo выводит информацию об автомобиле.
        // Protected — доступен в этом классе и в классах-наследниках.
        protected virtual void DisplayInfo()
        {
            Console.WriteLine($"Марка: {make}, Модель: {model}, Год выпуска: {Year}");
        }

        // Метод вызова DisplayInfo из Program, так как protected напрямую недоступен
        public void ShowInfo()
        {
            DisplayInfo(); // косвенный вызов защищенного метода
        }
    }
    
    // Производный класс ElectricCar — электромобиль.
    public class ElectricCar : Car
    {
        // Емкость аккумулятора (только для внутреннего использования)
        private double batteryCapacity;

        // Установка емкости аккумулятора.
        // Public — доступен откуда угодно.
        public void SetBatteryCapacity(double capacity)
        {
            batteryCapacity = capacity;
        }
        
        // Переопределение метода DisplayInfo для вывода полной информации об электромобиле.
        protected override void DisplayInfo()
        {
            base.DisplayInfo(); // выводим общую информацию из базового класса
            Console.WriteLine($"Емкость аккумулятора: {batteryCapacity} кВт⋅ч");
        }

        // Метод вызова DisplayInfo из Program
        public void ShowInfo()
        {
            DisplayInfo(); // косвенный вызов защищенного метода
        }
    }
}
