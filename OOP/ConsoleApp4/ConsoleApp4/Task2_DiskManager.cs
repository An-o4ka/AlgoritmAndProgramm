public class Task2_DiskManager
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Список доступных дисков ===");
        foreach (var drive in DriveInfo.GetDrives())
        {
            Console.WriteLine($"{drive.Name} - {(drive.IsReady ? FormatBytes(drive.AvailableFreeSpace) + " свободно" : "Недоступен")}");
        }

        Console.Write("Выберите диск (например, C:): ");
        string driveLetter = Console.ReadLine();
        string path = driveLetter + "\\";

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Неверный путь.");
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Диск: " + path);
            foreach (var dir in Directory.GetDirectories(path))
                Console.WriteLine("[D] " + Path.GetFileName(dir));
            foreach (var file in Directory.GetFiles(path))
                Console.WriteLine("[F] " + Path.GetFileName(file));

            Console.WriteLine("\nКоманды: mkdir <имя>, mkfile <имя>, del <имя>, info, exit");
            Console.Write("> ");
            var parts = Console.ReadLine().Split(' ', 2);
            string command = parts[0];
            string argument = parts.Length > 1 ? parts[1] : "";

            switch (command)
            {
                case "mkdir":
                    Directory.CreateDirectory(Path.Combine(path, argument));
                    break;
                case "mkfile":
                    File.WriteAllText(Path.Combine(path, argument), "");
                    break;
                case "del":
                    string delPath = Path.Combine(path, argument);
                    if (Directory.Exists(delPath)) Directory.Delete(delPath, true);
                    else if (File.Exists(delPath)) File.Delete(delPath);
                    break;
                case "info":
                    DriveInfo info = new DriveInfo(path);
                    Console.WriteLine($"Объем: {FormatBytes(info.TotalSize)}");
                    Console.WriteLine($"Свободно: {FormatBytes(info.AvailableFreeSpace)}");
                    Console.WriteLine($"ФС: {info.DriveFormat}");
                    Console.WriteLine($"Тип: {info.DriveType}");
                    Console.ReadKey();
                    break;
                case "exit":
                    return;
            }
        }
    }

    static string FormatBytes(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len /= 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }
}
