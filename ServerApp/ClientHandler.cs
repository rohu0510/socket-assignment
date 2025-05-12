using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public static class ClientHandler
{
    public static void Handle(TcpClient client)
    {
        try
        {
            using NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            string encryptedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            string message = AesEncryption.Decrypt(encryptedMessage);

            Console.WriteLine($"Received from client: {message}");

            string[] parts = message.Split('-');
            if (parts.Length != 2)
            {
                SendMessage(stream, "EMPTY");
                return;
            }

            string setKey = parts[0];
            string subKey = parts[1];

            if (DataStore.Lookup(setKey, subKey, out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    string currentTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                    SendMessage(stream, currentTime);
                    Thread.Sleep(1000);
                }
            }
            else
            {
                SendMessage(stream, "EMPTY");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error handling client: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Served the request.");
            client.Close();
            Console.WriteLine("Client disconnected.");
        }
    }

    private static void SendMessage(NetworkStream stream, string message)
    {
        string encrypted = AesEncryption.Encrypt(message);
        byte[] msg = Encoding.UTF8.GetBytes(encrypted);
        stream.Write(msg, 0, msg.Length);
    }
}