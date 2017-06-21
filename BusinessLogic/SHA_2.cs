using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SHA_2
    {
        public string Hash(string input)
        {
            SHA256 mySha = SHA256Managed.Create();
            return Convert.ToBase64String(mySha.ComputeHash(Encoding.Unicode.GetBytes(input)));
        }
    }
}
