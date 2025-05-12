using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesEncryption
{
    private static readonly string keyString = "ThisIsASecretKey";
    private static readonly string ivString = "ThisIsAnInitVect";

    public static string Encrypt(string plainText)
    {
        byte[] key = Encoding.UTF8.GetBytes(keyString);
        byte[] iv = Encoding.UTF8.GetBytes(ivString);
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        using MemoryStream ms = new();
        using CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
        using StreamWriter writer = new(cs);
        writer.Write(plainText);
        writer.Close();
        return Convert.ToBase64String(ms.ToArray());
    }

    public static string Decrypt(string cipherText)
    {
        byte[] key = Encoding.UTF8.GetBytes(keyString);
        byte[] iv = Encoding.UTF8.GetBytes(ivString);
        byte[] buffer = Convert.FromBase64String(cipherText);
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        using MemoryStream ms = new(buffer);
        using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using StreamReader reader = new(cs);
        return reader.ReadToEnd();
    }
}