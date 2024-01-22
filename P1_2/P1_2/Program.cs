using System;
using System.Security.Cryptography;
using System.IO;

namespace P1_2
{
    class part2{
        static void Main(string[] args){
            string secretString = args[0];
            string Encryption = args[1];

            int day = 3;
            int hour = 11;
            int min = 0;
            for (int i = 0; i <= 1440; i++){
                DateTime dt = new DateTime(2020, 7, day, hour, min, 0);
                TimeSpan ts = dt.Subtract(new DateTime(1970, 1, 1));
                Random rng = new Random((int)ts.TotalMinutes);
                byte[] key = BitConverter.GetBytes(rng.NextDouble());

                if (Encrypt(key, secretString).Equals(Encryption)){
                    Console.WriteLine(ts.TotalMinutes);
                }
                min += 1;
                if(min == 60){
                    hour +=1; 
                    min = 0;
                }
                if(hour == 24){
                    day +=1;
                    hour = 0;
                }
            }
        }

        private static string Encrypt(byte[] key, string secretString)
        {
            DES csp = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(secretString);
            sw.Flush();
            cs.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
    }
}
