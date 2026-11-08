using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.Odbc;

namespace Pag_Net.Tools.CryptFile
{
    public class Cryptf
    {

        public string DescryptString { get; set; }


        //  Call this function to remove the key from memory after use for security
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);


        public void FileEncrypt(string sInputFilename,
           string sOutputFilename//,
           //string sKey
               )
        {

            //__________ CHAVE CRYPTOGRAFIA DE ARQUIVO______________________________
            string sKey = "00141722";
            //______________________________________________________________________
            //______________________________________________________________________
            //______________________________________________________________________
            //______________________________________________________________________


            FileStream fsInput = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);

            FileStream fsEncrypted = new FileStream(sOutputFilename,
               FileMode.Create,
               FileAccess.Write);
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted,
               desencrypt,
               CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }

        public void FileDecrypt(string sInputFilename,
           string sOutputFilename//,
           //string sKey
               )
        {


            //__________ CHAVE CRYPTOGRAFIA DE ARQUIVO______________________________
            string sKey = "00141722";
            //______________________________________________________________________
            //______________________________________________________________________
            //______________________________________________________________________
            //______________________________________________________________________

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread,
               desdecrypt,
               CryptoStreamMode.Read);

            //Print the contents of the decrypted file.


            StreamReader x = new StreamReader(cryptostreamDecr);

            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }

        public string FileDecryptToString(string sInputFilename//,
           //string sKey
            )
        {

            //__________ CHAVE CRYPTOGRAFIA DE ARQUIVO______________________________
            string sKey = "00141722";
            //______________________________________________________________________
            //______________________________________________________________________
            //______________________________________________________________________
            //______________________________________________________________________



            // For additional security Pin the key.
            GCHandle gch = GCHandle.Alloc(sKey, GCHandleType.Pinned);


            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename,
               FileMode.Open,
               FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread,
               desdecrypt,
               CryptoStreamMode.Read);

            //Print the contents of the decrypted file.


            StreamReader x = new StreamReader(cryptostreamDecr);
            return x.ReadToEnd().ToString();

            ZeroMemory(gch.AddrOfPinnedObject(), sKey.Length * 2);
            gch.Free();


        }


        //static void x()
        // {
        // Must be 64 bits, 8 bytes.
        // Distribute this key to the user who will decrypt this file.
        //string sSecretKey;

        // Get the Key for the file to Encrypt.
        //sSecretKey = GenerateKey();
        //sSecretKey = "00141722";

        // For additional security Pin the key.
        //GCHandle gch = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned);

        // Encrypt the file.        
        //EncryptFile(@"D:\Projects\p0002_LoginPagNet\Pag\Pag_Net\ConectionX.xml",
        //   @"D:\Projects\p0002_LoginPagNet\Pag\Pag_Net\InfoX.dll",
        //  sSecretKey);

        // Decrypt the file.
        //DecryptFile(@"D:\Projects\p0002_LoginPagNet\Pag\Pag_Net\InfoX.dll",
        //   @"D:\Projects\p0002_LoginPagNet\Pag\Pag_Net\Decrypted.txt",
        //   sSecretKey);



        // Remove the Key from memory. 
        //ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2);
        // gch.Free();

        //Console.WriteLine(elias);
        // Console.ReadKey();






        /*
        bllPackgeConnection x = new bllPackgeConnection("PAG", "ELIAS", "PRD", "+17jesusbom");
        Console.WriteLine(x.ListConnections.Count().ToString());
            
        int a = 0;

        for (a = 0; a < x.ListConnections.Count(); a++)
        {
            Console.WriteLine(x.ListConnections[a].DataBase.ToString());
        }
         */


        // Function to Generate a 64 bits Key.




        //}


        /*
        static string GenerateKey()
        {
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

            // Use the Automatically generated key for Encryption. 
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }
        */
    }




}

