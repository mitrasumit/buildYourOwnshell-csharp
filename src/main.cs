using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

// Uncomment this line to pass the first stage
var pathVar=Environment.GetEnvironmentVariable("PATH");
var pathArray=pathVar.Split(Path.PathSeparator);

bool foundFlag=false;

while (true)
{
Console.Write("$ ");
//Reading User Input
var command=Console.ReadLine();

if(string.Equals(command,"exit 0"))
    break;
//Writing user input
if(command.Contains("type echo"))
    Console.WriteLine("echo is a shell builtin");

else if(command.Contains("type exit"))
    Console.WriteLine("exit is a shell builtin");

else if(command.Contains("type type"))
    Console.WriteLine("type is a shell builtin");

else if(command.Contains("type"))
{

        foreach (var address in pathArray)
        {
            var wholePath = Path.Join(address, command.Replace("type", "").Trim());
            if (File.Exists(wholePath))
            {
                Console.WriteLine($"{command.Replace("type", "").Trim()} is {wholePath}");
                foundFlag = true;
            }
        }

        if (foundFlag == false)
        {
            Console.WriteLine($"{command.Replace("type", "").Trim()}: not found");
        }

    }

else if(command.Contains("echo"))
    Console.WriteLine($"{command.Replace("echo","").Trim()}");
else
    Console.WriteLine($"{command}: command not found");
// Wait for user input
//Console.ReadLine();
}
