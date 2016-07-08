using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptDecryptSoftwareExpress
{
    public class UtilCryptDecrypt
    {
        /// <summary>
        /// Criptografa o pinblock aberto, na verdade esse processo já é feito pela software express
        /// o pinblock já é passado para a autorizadora criptografado o método foi criado apenas a título 
        /// de conhecimento
        /// </summary>
        /// <param name="securityKeyArrayK1">Primeira parte da chave K1 no formato array de bytes</param>
        /// <param name="securityKeyArrayK2">Segunda parte da chave K2 no formato array de bytes</param>
        /// <param name="securityKeyArrayK3">Terceira parte da chave K3 no formato array de bytes</param>
        /// <param name="openPinBlock">Pinblock aberto passado pelo TEF</param>
        /// <returns></returns>
        public static string CipherPinBlock(byte[] securityKeyArrayK1, byte[] securityKeyArrayK2, byte[] securityKeyArrayK3, string openPinBlock)
        {
            //Convertendo o pinblock aberto em um array de bytes
            byte[] toEncryptedArray1 = StringToByteArray(openPinBlock);
            //Convertendo a chave parte k1 em array de bytes

            //Encripta o conteúdo retornando um array de bytes criptografado
            var cipher = ComputeTripleDesEncryption(toEncryptedArray1, securityKeyArrayK1);
            //Converter o array de bytes criptografado em string hexadecimal
            string DES1 = ConvertByteArrayToString(cipher);



            byte[] toDencryptedArray2 = StringToByteArray(DES1);

            var decripted = Decrypt(toDencryptedArray2, securityKeyArrayK2);

            string DES2 = ConvertByteArrayToString(decripted);



            //Convertendo o pinblock aberto em um array de bytes
            byte[] toEncryptedArray3 = StringToByteArray(DES2);
            //Convertendo a chave parte k1 em array de bytes

            //Encripta o conteúdo retornando um array de bytes criptografado
            var cipher3 = ComputeTripleDesEncryption(toEncryptedArray3, securityKeyArrayK3);
            //Converter o array de bytes criptografado em string hexadecimal
            string DES3 = ConvertByteArrayToString(cipher3);

            return DES3;
        }

        /// <summary>
        /// Descriptograda o pinblock enviado pelo TEF após esse processo é necessário aplicar o operador XOR
        /// entre o pinblock descriptogradado e o partial pan para obter informações como PIN e etc.
        /// </summary>
        /// <param name="securityKeyArrayK1">Primeira parte da chave K1 no formato array de bytes</param>
        /// <param name="securityKeyArrayK2">Segunda parte da chave K2 no formato array de bytes</param>
        /// <param name="securityKeyArrayK3">Terceira parte da chave K3 no formato array de bytes</param>
        /// <param name="encriptedPinBlock">PinBlock encriptado passado pelo TEF</param>
        /// <returns>String contendo o pinblock descriptografado</returns>
        public static string DecryptPinBlock(byte[] securityKeyArrayK1, byte[] securityKeyArrayK2, byte[] securityKeyArrayK3, string encriptedPinBlock)
        {
            //Convertendo o pinblock aberto em um array de bytes
            byte[] toEncryptedArray1 = StringToByteArray(encriptedPinBlock);
            //Convertendo a chave parte k1 em array de bytes

            //Encripta o conteúdo retornando um array de bytes criptografado
            var cipher = Decrypt(toEncryptedArray1, securityKeyArrayK1);
            //Converter o array de bytes criptografado em string hexadecimal
            string DES1 = ConvertByteArrayToString(cipher);



            byte[] toDencryptedArray2 = StringToByteArray(DES1);

            var decripted = ComputeTripleDesEncryption(toDencryptedArray2, securityKeyArrayK2);

            string DES2 = ConvertByteArrayToString(decripted);



            //Convertendo o pinblock aberto em um array de bytes
            byte[] toEncryptedArray3 = StringToByteArray(DES2);
            //Convertendo a chave parte k1 em array de bytes

            //Encripta o conteúdo retornando um array de bytes criptografado
            var cipher3 = Decrypt(toEncryptedArray3, securityKeyArrayK3);
            //Converter o array de bytes criptografado em string hexadecimal
            string DES3 = ConvertByteArrayToString(cipher3);

            return DES3;
        }

        /// <summary>
        /// Recebe uma string hexadecimal e converte em array de bytes[] 
        /// bloco 16 posições em hexadecimal (apenas caracteres 0-9,A-F)
        /// Ex: [0A12B7152BF38C7C] 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns>byte[]</returns>
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
        
        //public static byte[] ConvertHexStringToByteArray(String hexString)
        //{
        //    int TotalNumberOfChars = hexString.Length;
        //    byte[] bytesArray = new byte[TotalNumberOfChars / 2];
        //    for (int i = 0; i < TotalNumberOfChars; i += 2)
        //    {
        //        bytesArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
        //    }
        //    return bytesArray;
        //}

        /// <summary>
        /// Converte um array de bytes[] em uma string hexadecimal
        /// Ex. de retorno D3EDF2222F11A643 -->bloco de 16 posições Hexadecimal
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns>string hexadecimal</returns>
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

        public static byte[] Decrypt(byte[] cipherText, byte[] key)
        {
            //byte[] inputArray = Convert.FromBase64String(cipherText);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = key;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.None;
            ICryptoTransform cTransform = des.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);
            return resultArray;
        }




    }
}
