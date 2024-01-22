using System;
using System.Security.Cryptography; // Aes
using System.Numerics; // BigInteger
using System.IO;

namespace P3
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] IV = get_bytes_from_string(args[0]); 
            BigInteger g_e= BigInteger.Parse(args[1]);
            BigInteger g_c= BigInteger.Parse(args[2]);
            BigInteger N_e= BigInteger.Parse(args[3]);
            BigInteger N_c= BigInteger.Parse(args[4]);
            BigInteger x = BigInteger.Parse(args[5]);
            BigInteger gy = BigInteger.Parse(args[6]);
            byte[] C = get_bytes_from_string(args[7]);
            string M = args[8];

            // Make sure you are familiar with the System.Numerics.BigInteger class and how to use some of the functions it has (Parse, Pow, ModPow, Subtract, ToByteArray, etc.)

            // you will be using BigInteger functions for almost all, if not all mathmatical operations. (Pow, ModPow, Subtract)
            // N = 2^(N_e) - N_c (this calculation needs to be done using BigInteger.Pow and BigInteger.Subtract)
            BigInteger N = BigInteger.Subtract(BigInteger.Pow(2, (int)N_e), N_c);
            // Diffie-Hellman key is g^(xy) mod N. In the input you are given g_y which is g^y. So to make the key you need to perform g_y^(x) using the BigInteger class
            // key = g_y^(x) mod N (this calculation needs to be done using BigInteger.ModPow)
            BigInteger key = BigInteger.ModPow(gy, x, N);
            // you can convert a BigInteger into a byte array using the BigInteger.ToByteArray() function/method
            byte[] keyBytes = key.ToByteArray();

            Console.Write(Decrypt(C, keyBytes, IV) + "," + BitConverter.ToString(Encrypt(M, keyBytes, IV)).Replace("-", " "));
            /*
            dotnet run "A2 2D 93 61 7F DC 0D 8E C6 3E A7 74 51 1B 24 B2" 251 465 255 1311 2101864342 8995936589171851885163650660432521853327227178155593274584417851704581358902 "F2 2C 95 FC 6B 98 BE 40 AE AD 9C 07 20 3B B3 9F F8 2F 6D 2D 69 D6 5D 40 0A 75 45 80 45 F2 DE C8 6E C0 FF 33 A4 97 8A AF 4A CD 6E 50 86 AA 3E DF" AfYw7Z6RzU9ZaGUloPhH3QpfA1AXWxnCGAXAwk3f6MoTx
            */
        }

        static byte[] get_bytes_from_string(string input)
        {
            var input_split = input.Split(' ');
            byte[] inputBytes = new byte[input_split.Length];
            int i = 0;
            foreach (string item in input_split)
            {
                inputBytes.SetValue(Convert.ToByte(item, 16), i);
                i++;
            }
            return inputBytes;
        }
        static byte[] Encrypt(string plainText, byte[] Key, byte[] IV) {  
            byte[] encrypted;  
            // Create a new AesManaged.    
            using(AesManaged aes = new AesManaged()) {  
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);  
                // Create MemoryStream    
                using(MemoryStream ms = new MemoryStream()) {  
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using(CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {  
                        // Create StreamWriter and write data to a stream    
                        using(StreamWriter sw = new StreamWriter(cs))  
                        sw.Write(plainText);  
                        encrypted = ms.ToArray();  
                    }  
                }  
            }  
            // Return encrypted data    
            return encrypted;  
        }  
        static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV) {  
            string plaintext = null;  
            // Create AesManaged    
            using(AesManaged aes = new AesManaged()) {  
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);  
                // Create the streams used for decryption.    
                using(MemoryStream ms = new MemoryStream(cipherText)) {  
                    // Create crypto stream    
                    using(CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {  
                        // Read crypto stream    
                        using(StreamReader reader = new StreamReader(cs))  
                        plaintext = reader.ReadToEnd();  
                    }  
                }  
            }  
            return plaintext;  
        }  
    }
}