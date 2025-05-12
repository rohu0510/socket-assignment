using System;
using System.Net.Sockets;
using System.Text;

public static class ClientService
{
    public static void SendMessage(string serverIp, int serverPort, string message)
    {
        try
        {
            using TcpClient client = new TcpClient();
            client.Connect(serverIp, serverPort);
            Console.WriteLine("Connected to server.");

            NetworkStream stream = client.GetStream();

            string encrypted = AesEncryption.Encrypt(message);
            byte[] dataToSend = Encoding.UTF8.GetBytes(encrypted);
            stream.Write(dataToSend, 0, dataToSend.Length);

            byte[] buffer = new byte[1024];
            int bytesRead;

            Console.WriteLine("Server response:");
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
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