using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private const string _securityKey = "BA73F294584334BA";
        static void Main(string[] args)
        {
            #region comentado
            //    string hex1 = "0A1234567890FFFF";
            //    string hex2 = "0000834353637383";
            //    int dec1 = Convert.ToInt32(hex1, 16);
            //    int dec2 = Convert.ToInt32(hex2, 16);
            //    //int result = dec1 ^ dec2;
            //    //string hexResult = result.ToString("X");
            //    //Console.WriteLine(hexResult);
            //    //Console.ReadKey();

            //    //Console.WriteLine(hex1 ^ hex2);  // logical exclusive-or
            //    // Bitwise exclusive-or:
            //    Console.WriteLine("0x{0:x}", 0xf8 ^ 0x3f);
            //    Console.ReadKey();
            //}

            //Process p = new Process();
            //p.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.Arguments = "/c ipconfig /all";
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.RedirectStandardOutput = true;
            //p.Start();

            //string output = p.StandardOutput.ReadToEnd();
            #endregion

            #region abrir working key
            //string CMD = "perl -e \" binmode *STDOUT; print pack 'H*','8C65E00F2D0B62C7702530CA0FBEB455C41525A31BFF15F132648D82674F121678648DBE13994FA0E3C569162B30B518CFB9F5E1FA02BEF11C49D5C4F61C60DC0A4C3900D671BD2F1EA34E77C2C6B94C771213556A06E79426514231D0C397BB0352368635672EDDC4595835E3E771E03DE99F668677C65028F204F7C9CB55B4B2EA44AE77C22BCF17DFCD9D9B1B597A9F24C6DAD52F088B2CFF27C7056E2E7360EE7D98ED32EF058B5636BCC80DF5ADF9972FCC42E40FB2B90F0F294ABC273BFD546B7921C447025004CF3AE9EE03D6FA7EB2DC32E358882543B73D0FC3D520D209687F25936D0D8997097BCC6B3339279124803D21F618A8BBB71AFAAD7EBB';\" | openssl rsautl -decrypt -oaep -inkey \"C:\\temp\\TESTE_CRIPTO\\RSA\\myPrivkey.pem";              // O comando a executar
            
            
            //string salvarComo = "c:\\temp\\meuArquivo1.txt";  // Nome do arquivo a ser salvo a saída
            //string saida = ExecutarComandoCMD(CMD); // Executa o comando

            //if (!File.Exists(salvarComo))
            //{         // Se o arquivo NÃO existir
            //    File.Create(salvarComo).Dispose();
            //    using (TextWriter tw = new StreamWriter(salvarComo))
            //    {
            //        tw.WriteLine(saida);
            //    }
            //}
            //Console.WriteLine(string.Format("O comando {0} foi executado e a saída foi salva no arquivo {1}", CMD, salvarComo));
            //Console.ReadLine();
            #endregion

            #region executa criptografia
            //var text = "9A02341";
            var text = "0A12B7152BF38C7C";
            var encryptedText = Encrypt(text,_securityKey);

            var decryptedText = Decrypt("MjI1MWE5ZWZlZDc2ZjRkMQ==", _securityKey);
 
            //Console.WriteLine("Passed Text = " + text);
            //Console.WriteLine("EncryptedText = " + encryptedText);
            Console.WriteLine("DecryptedText = " + decryptedText);
 
            Console.ReadLine();
            #endregion

            //byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey));
        }

        static string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }

        public static string ExecutarComandoCMD(string ComandoCMD)
        {
            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                // Formata a string para passar como argumento para o cmd.exe
                processo.StartInfo.Arguments = string.Format("/c {0}", ComandoCMD);

                // Define a área de trabalho como diretório atual de trabalho
                processo.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Para redirecionar a saída para uma string ou StreamReader 
                processo.StartInfo.RedirectStandardOutput = true;

                // Para redirecionar a saída de um processo
                processo.StartInfo.UseShellExecute = false;

                // Para não criar a janela do cmd.exe
                processo.StartInfo.CreateNoWindow = true;

                // Inicia o cmd.exe
                processo.Start();

                // Aguarda o término
                processo.WaitForExit();

                // Lê a saída do processo, aqui poderia ser usado também um StreamReader
                string saida = processo.StandardOutput.ReadToEnd();
                return saida;
            }
        }

        public static string Encrypt(string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.None;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.None;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


        /// <summary>
        /// This method is used to convert the plain text to Encrypted/Un-Readable Text format.
        /// </summary>
        /// <param name="PlainText">Plain Text to Encrypt before transferring over the network.</param>
        /// <returns>Cipher Text</returns>
        
        public static string EncryptPlainTextToCipherText(string PlainText)
        {
            
            //Getting the bytes of Input String.
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey));

            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();
            
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
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);



        }

        public static string DecryptCipherTextToPlainText(string textoCriptografado)
        {

            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(_securityKey));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(textoCriptografado);

            string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return plaintext;

            
        }





        public static string DecryptCipherTextToPlainText2(string textoCriptografado)
        {
            try
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Mode = CipherMode.ECB;

                byte[] ciphertext = Convert.FromBase64String(textoCriptografado);

                byte[] key = Encoding.ASCII.GetBytes(_securityKey);

                byte[] IV = Encoding.ASCII.GetBytes("init vec");

                des.Key = key;
                des.IV = IV;

                ICryptoTransform Decryptor = des.CreateDecryptor(des.Key, des.IV);

                MemoryStream ms = new MemoryStream();
                ms.Write(ciphertext, 0, ciphertext.Length);
                CryptoStream cs = new CryptoStream(ms, Decryptor, CryptoStreamMode.Write);

                byte[] by_plaintext = ms.ToArray();
                string plaintext = Encoding.ASCII.GetString(by_plaintext);// Convert.ToBase64String( by_plaintext );

                //cs.Close();

                return plaintext;

            }
            catch (Exception e)
            {
                return e.Message;
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }




    }
}
