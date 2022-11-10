using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Fleet.io_cx_system
{
    class Hashing
    {
        public string Encrypt(string x)
        {
            //Hashing variable
            string hash = "Fuco@2021$";
            byte[] Data = UTF8Encoding.UTF8.GetBytes(x);
            //Md5 enconding
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            //Computehash
            tripleDES.Key = Md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripleDES.Mode = CipherMode.ECB;
            //Create encrypter
            ICryptoTransform cryptoTrans = tripleDES.CreateEncryptor();
            byte[] Outcome = cryptoTrans.TransformFinalBlock(Data, 0, Data.Length);
            //return variable
            return Convert.ToBase64String(Outcome);

        }
    }
}
