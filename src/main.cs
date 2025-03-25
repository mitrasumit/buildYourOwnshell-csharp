using System.Diagnostics;

string builtinPresent;

bool whileFlag=true;

while (whileFlag)
{
    Console.Write("$ ");


    string? command = Console.ReadLine();

    if (!CheckIfValidCommand(command))
    {
        builtinPresent = " ";
    }
    else
    {
        builtinPresent = command.TrimEnd().Split(" ")[0];
    }

    switch (builtinPresent)
    {
        case "exit":
            {
                if (command.Contains("exit 0"))
                    whileFlag = false;
                else
                    Console.WriteLine($"{command}: command not found");
                break;
            }

        case "echo":
            {
                Console.WriteLine(command.Replace("echo", "").Trim());
                break;
            }

        case "type":
            {
                typeBuiltin(command);
                break;
            }
        
        case "pwd":
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
                break;
            }
        default:
            {
                customCommand(command);
                //Console.WriteLine($"{command}: command not found");
                break;
            }
    }
}

static void customCommand(string command)
{
    string[] paths = GetPath();

    string[] commandParts=command.Split(" ");

    bool foundFlag = false;


    foreach (var path in paths)
    {
        var wholePath = Path.Join(path, commandParts[0]);

        if (File.Exists(wholePath))
        {
            Process.Start(commandParts[0],commandParts[1]);
            foundFlag=true;
            break;
        }
    }

    if (foundFlag == false)
            Console.WriteLine($"{commandParts[0].Trim()}: not found");


}

static bool CheckIfValidCommand(string command)
{
    command=command.Trim();

    if(string.IsNullOrEmpty(command) || string.IsNullOrWhiteSpace(command))
    {
        return false;
    }

    return true;
}

static void typeBuiltin(string command)
{
    if(command.Contains("type echo"))
    Console.WriteLine("echo is a shell builtin");

    else if(command.Contains("type exit"))
    Console.WriteLine("exit is a shell builtin");

    else if(command.Contains("type type"))
        Console.WriteLine("type is a shell builtin");
    else
    {
        var pathArray = GetPath();

        bool foundFlag = false;

        foreach (var path in pathArray)
        {
            var wholePath = Path.Join(path, command.Replace("type", "").Trim());
            if (File.Exists(wholePath))
            {
                Console.WriteLine($"{command.Replace("type", "").Trim()} is {wholePath}");
                foundFlag = true;
                break;
            }
        }
        if (foundFlag == false)
            Console.WriteLine($"{command.Replace("type", "").Trim()}: not found");
    }
}

static string[] GetPath()
{
    var pathVar = Environment.GetEnvironmentVariable("PATH");
    var pathArray = pathVar.Split(Path.PathSeparator);

    return pathArray;

}
