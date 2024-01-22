using System;
using System.Linq;
using System.Collections.Generic;

namespace P2
{
    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            string sol1= "NA";
            string sol2= "NA";
            byte salt = Convert.ToByte(args[0], 16);

            IDictionary<string, string> hashes = new Dictionary<string, string>();

            int count = 0;
            string currentPass = RandomString(5);
            string currentHash = CreateMD5(currentPass,salt);

            bool found = false; 
            
            while(!found){
                if(hashes.ContainsKey(currentHash)){
                    if(hashes[currentHash] != currentPass){
                        found = true;
                        sol1 = currentPass;
                        sol2 = hashes[currentHash];
                        break;
                    }
                }
                else{
                    hashes.Add(currentHash, currentPass);
                }
                currentPass = RandomString(5);
                currentHash = CreateMD5(currentPass,salt);
                count++;
                //Console.WriteLine(pass1.ToString() + "," + pass2.ToString());
                //Console.WriteLine("Comparing: " + currentHash+ "       " + CreateMD5(pass2, salt));
            }
            
            //Console.WriteLine(sol1 + ": " + currentHash + "  and  " + sol2 + ": " + CreateMD5(sol1, salt));
            Console.WriteLine(sol1 + "," + sol2); 
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string CreateMD5(string input, byte salt)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] saltBytes = new byte[]{salt};

                //Combine SaltBytes and inputBytes into one array.
                byte[] pw = new byte[inputBytes.Length + saltBytes.Length];
                for(int i = 0; i<inputBytes.Length ; i++){
                    pw[i] = inputBytes[i];
                }
                for(int i = 0; i<saltBytes.Length; i++){
                    pw[inputBytes.Length + i] = saltBytes[i];
                }

                byte[] hashBytes = md5.ComputeHash(pw);
                byte[] shortenedHash = new byte[5];
                for (int i = 0; i < 5; i++){
                    shortenedHash[i] = hashBytes[i];
                }
                return BitConverter.ToString(shortenedHash).Replace("-", " "); 
            }
        }
    }
}
