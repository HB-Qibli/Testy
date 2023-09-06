using System;

namespace System
{

        public class Displayer
        {
                public void WriteLine(string message, int speed = 80, ConsoleColor color = ConsoleColor.White, int encrypted = 0)
                {
                        ConsoleColor originalColor = Console.ForegroundColor;

                        Console.ForegroundColor = color;

                        for (int i = 0; i < message.Length; i++)
                        {
                                Console.Write(message[i]);
                                System.Threading.Thread.Sleep(speed);
                        }
                        Console.ForegroundColor = originalColor;
                        Console.WriteLine(); //add a new line at the end
                }
               
                   // Display encrypted text (it will automatically decrypt before displaying)
    public static void DisplayEncryptedText(string encryptedText, int speed = 80, string key)
    {
        string decryptedText = DecryptString(encryptedText, key);
        WriteLine(decryptedText, speed);
    }

  // AES encryption, default is 256 bit 
    public string EncryptString(string input, string key)
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

    public string DecryptString(string cipherText, string key)
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
