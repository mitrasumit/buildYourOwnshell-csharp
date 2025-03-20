using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

// Uncomment this line to pass the first stage
while (true)
{
Console.Write("$ ");
//Reading User Input
var command=Console.ReadLine();

if(string.Equals(command,"exit 0"))
    break;
//Writing user input
Console.WriteLine($"{command.Replace("echo","")}");

//Console.WriteLine($"{command}: command not found");
// Wait for user input
//Console.ReadLine();
}
