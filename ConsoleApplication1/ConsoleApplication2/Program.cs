using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        string K1 = "0x0123456789ABCDEF";
        string K2 = "0xFEDCBA9876543210";
        private static string _securityKey = "BA73F294584334BA";
        private static int Num;
        
        static void Main(string[] args)
        {

            //byte[] toEncryptedArray = StringToByteArray(textoPlano);
            byte[] toEncryptedArray = StringToByteArray("0A12B7152BF38C7C");
            byte[] securityKeyArray = StringToByteArray("BA73F294584334BA");
            var cipher = ComputeTripleDesEncryption(toEncryptedArray, securityKeyArray);
            //string teste = BitConverter.tos
            //var cipher = EncryptPlainTextToCipherText("0A12B7152BF38C7C");
            var DES1 = ConvertByteArrayToString(cipher);
            Console.WriteLine(Num.ToString("X"));
            Console.ReadKey();

        }

        public static byte[] StringToByteArray(String hex)
        {
            if (hex.Substring(0, 2) == "0x")
                hex = hex.Substring(2);
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static byte[] ConvertHexStringToByteArray(String hexString)
        {
            int TotalNumberOfChars = hexString.Length;
            byte[] bytesArray = new byte[TotalNumberOfChars / 2];
            for (int i = 0; i < TotalNumberOfChars; i += 2)
            {
                bytesArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytesArray;
        }

        public static string ConvertByteArrayToString(byte[] byteArray)
        {
            string hexString = BitConverter.ToString(byteArray);
            return hexString.Replace("-", "");
        }

        public static byte[] ComputeTripleDesEncryption(byte[] plainText, byte[] key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //des.KeySize = 128;
            //MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            ////Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            //byte[] securityKeyArray = objMD5CryptoService.ComputeHash(key);
            des.Key = key;
            des.GenerateIV();
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.None;

            ICryptoTransform ic = des.CreateEncryptor();

            byte[] enc = ic.TransformFinalBlock(plainText, 0, plainText.Length);

            return enc;
        }
        
        
        public static byte[] EncryptPlainTextToCipherText(string textoPlano)
        {

            //Getting the bytes of Input String.
            byte[] toEncryptedArray = StringToByteArray(textoPlano);

            //byte[] securityKeyArray = StringToByteArray(_securityKey);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(StringToByteArray(_securityKey));

            //De-allocatinng the memory after doing the Job.
            //objMD5CryptoService.Clear();

            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;

            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;

            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.None;

            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();

            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);

            //Releasing the Memory Occupied by TripleDES Service Provider for Encryption.
            objTripleDESCryptoService.Clear();

            //Convert and return the encrypted data/byte into string format.
            //return Convert.ToBase64String(resultArray, 0, resultArray.Length);

            return resultArray;

        }

        //private byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0 };

        //public byte[] EncryptIso(byte[] plainText, byte[] key)
        //{
        //    //// create the crypto service provider
        //    TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();
        //    des3.Mode = CipherMode.CBC;

        //    des3.Padding = PaddingMode.None;

        //    // create the key
        //    PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Convert.ToBase64String(key), new byte[0]);
        //    des3.Key = passwordDeriveBytes.CryptDeriveKey("TripleDES", "SHA1", 0, this.IV);
        //    des3.IV = this.IV;

        //    MemoryStream memoryStream = new MemoryStream();
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream, des3.CreateEncryptor(), CryptoStreamMode.Write);
        //    cryptoStream.Write(plainText, 0, plainText.Length);
        //    cryptoStream.FlushFinalBlock();

        //    return memoryStream.ToArray();
        //}

	
    }
}
