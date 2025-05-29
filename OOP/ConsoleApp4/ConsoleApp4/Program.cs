class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Меню заданий ===");
            Console.WriteLine("1. Проводник файловой системы");
            Console.WriteLine("2. Управление дисками");
            Console.WriteLine("3. Модифицированный проводник");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите задание: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1_FileExplorer.Run();
                    break;
                case "2":
                    Task2_DiskManager.Run();
                    break;
                case "3":
                    Task3_ModifiedExplorer.Run();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
        }
    }
}