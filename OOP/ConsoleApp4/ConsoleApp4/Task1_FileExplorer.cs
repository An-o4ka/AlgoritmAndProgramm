public class Task1_FileExplorer
{
    public static void Run()
    {
        string currentPath = Directory.GetCurrentDirectory();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Проводник. Текущий каталог: " + currentPath);
            Console.WriteLine("\nСодержимое:");
            foreach (var dir in Directory.GetDirectories(currentPath))
                Console.WriteLine(" [D] " + Path.GetFileName(dir));
            foreach (var file in Directory.GetFiles(currentPath))
                Console.WriteLine(" [F] " + Path.GetFileName(file));

            Console.WriteLine("\nКоманды: cd <папка>, up, open <файл>, mkdir <имя>, mkfile <имя>, del <имя>, exit");
            Console.Write("> ");
            string[] input = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 0) continue;

            string command = input[0];
            string argument = input.Length > 1 ? input[1] : "";

            switch (command)
            {
                case "cd":
                    string newPath = Path.Combine(currentPath, argument);
                    if (Directory.Exists(newPath)) currentPath = newPath;
                    else Console.WriteLine("Папка не найдена.");
                    break;
                case "up":
                    var parent = Directory.GetParent(currentPath);
                    if (parent != null) currentPath = parent.FullName;
                    break;
                case "open":
                    string filePath = Path.Combine(currentPath, argument);
                    if (File.Exists(filePath))
                        Console.WriteLine(File.ReadAllText(filePath));
                    else Console.WriteLine("Файл не найден.");
                    break;
                case "mkdir":
                    Directory.CreateDirectory(Path.Combine(currentPath, argument));
                    break;
                case "mkfile":
                    File.WriteAllText(Path.Combine(currentPath, argument), "");
                    break;
                case "del":
                    string delPath = Path.Combine(currentPath, argument);
                    if (Directory.Exists(delPath)) Directory.Delete(delPath, true);
                    else if (File.Exists(delPath)) File.Delete(delPath);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }
}
