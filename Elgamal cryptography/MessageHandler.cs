using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elgamal_cryptography
{
    public static class MessageHandler
    {
        public static int GenerateMessage()
        {
            return new Random().Next(200);
        }

        public static string HashMessage(int message)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = BitConverter.GetBytes(message);
                Array.Reverse(inputBytes);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //convert the byte array to hex string
                StringBuilder sb = new StringBuilder();
                for(int i =0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
