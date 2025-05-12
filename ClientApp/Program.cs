using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Server IP (e.g., 127.0.0.1): ");
        string serverIp = Console.ReadLine() ?? "127.0.0.1";

        Console.Write("Enter Server Port (e.g., 5000): ");
        string portInput = Console.ReadLine() ?? string.Empty;
        int serverPort = int.TryParse(portInput, out int parsedPort) ? parsedPort : 5000;

        Console.Write("Enter message to send (e.g., SetA-One): ");
        string message = Console.ReadLine() ?? "SetA-One";

        ClientService.SendMessage(serverIp, serverPort, message);
    }
}