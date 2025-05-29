public class Task3_ModifiedExplorer
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("=== Выбор диска ===");
        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady)
                Console.WriteLine($"{drive.Name} - {drive.DriveFormat} - {FormatBytes(drive.AvailableFreeSpace)} свободно");
        }

        Console.Write("Введите диск (например, D:): ");
        string root = Console.ReadLine() + "\\";
        if (!Directory.Exists(root)) return;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Текущий путь: " + root);
            foreach (var dir in Directory.GetDirectories(root)) Console.WriteLine("[D] " + Path.GetFileName(dir));
            foreach (var file in Directory.GetFiles(root)) Console.WriteLine("[F] " + Path.GetFileName(file));

            Console.WriteLine("\nКоманды: mkdir <имя>, mkfile <имя>, del <имя>, exit");
            Console.Write("> ");
            string[] parts = Console.ReadLine().Split(' ', 2);
            string command = parts[0];
            string argument = parts.Length > 1 ? parts[1] : "";

            switch (command)
            {
                case "mkdir":
                    Directory.CreateDirectory(Path.Combine(root, argument));
                    break;
                case "mkfile":
                    string filePath = Path.Combine(root, argument);
                    Console.WriteLine("Введите содержимое файла (пустая строка завершит ввод):");
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        while (true)
                        {
                            string line = Console.ReadLine();
                            if (string.IsNullOrEmpty(line)) break;
                            sw.WriteLine(line);
                        }
                    }
                    break;
                case "del":
                    string delPath = Path.Combine(root, argument);
                    if (Directory.Exists(delPath)) Directory.Delete(delPath, true);
                    else if (File.Exists(delPath)) File.Delete(delPath);
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
