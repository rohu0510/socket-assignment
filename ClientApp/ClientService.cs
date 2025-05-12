using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public static class ClientService
{
    public static async Task SendMessageAsync(string serverIp, int serverPort, string message)
    {
        try
        {
            using TcpClient client = new TcpClient();
            await client.ConnectAsync(serverIp, serverPort);
            Console.WriteLine("Connected to server.");

            using NetworkStream stream = client.GetStream();

            string encrypted = AesEncryption.Encrypt(message);
            byte[] dataToSend = Encoding.UTF8.GetBytes(encrypted);
            await stream.WriteAsync(dataToSend, 0, dataToSend.Length);

            byte[] buffer = new byte[1024];
            int bytesRead;

            Console.WriteLine("Server response:");
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string encryptedResponse = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string decrypted = AesEncryption.Decrypt(encryptedResponse);
                Console.WriteLine(decrypted);

                if (decrypted == "EMPTY")
                {
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}