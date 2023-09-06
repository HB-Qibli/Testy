using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace System
{

        public class Displayer
        {
                public void WriteLine(string message, int speed = 80, ConsoleColor color = ConsoleColor.White)
                {
                        ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            string[] lines = message.Split('\n'); // Split text into lines

            foreach (string line in lines)
            {
                foreach (char character in line)
                {
                    Console.Write(character);
                    System.Threading.Thread.Sleep(speed);
                }

                // Move to the next line
                Console.WriteLine();
            }

            Console.ForegroundColor = originalColor;
            Console.WriteLine();
        }

        // Display encrypted text (it will automatically decrypt before displaying)
        public static void DisplayEncryptedText(string encryptedText, string key, int speed = 80)
        {
            string decryptedText = DecryptString(encryptedText, key);
            WriteLine(decryptedText, speed); //maybe later make encrypted text a diff colour
        }
                          string[] lines = text.Split('\n'); // Split text into lines

        foreach (string line in lines)
        {
            foreach (char character in line)
            {
                Console.Write(character);
                System.Threading.Thread.Sleep(speed);
            }

            // Move to the next line
            Console.WriteLine();
        }

        Console.ForegroundColor = originalColor;
        Console.WriteLine();
                }

                   // Display encrypted text (it will automatically decrypt before displaying)
    public static void DisplayEncryptedText(string encryptedText, int speed = 80, string key)
    {
        string decryptedText = DecryptString(encryptedText, key);
        WriteLine(decryptedText, speed); //maybe later make encrypted text a diff colour
    }

        // AES encryption, default is 256 bit 
        public static string EncryptString(string input, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16]; // Initialization Vector

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(input);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptString(string cipherText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
