using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.Write("Enter IP to bind (e.g., 127.0.0.1): ");
        string ipString = Console.ReadLine() ?? "127.0.0.1";

        Console.Write("Enter port to listen on (e.g., 5000): ");
        string portInput = Console.ReadLine() ?? string.Empty;
        int port = int.TryParse(portInput, out int parsedPort) ? parsedPort : 5000;

        IPAddress ip = IPAddress.TryParse(ipString, out IPAddress? parsedIp) && parsedIp != null ? parsedIp : IPAddress.Any;

        TcpListener listener = new TcpListener(ip, port);
        listener.Start();

        Console.WriteLine($"Server started on {ip}:{port}. Waiting for clients to connect...");

        while (true)
        {
            TcpClient client = await listener.AcceptTcpClientAsync();
            Console.WriteLine($"Client connected from {client.Client.RemoteEndPoint}");
            _ = Task.Run(() => ClientHandler.HandleAsync(client)); // fire-and-forget
        }
    }
}