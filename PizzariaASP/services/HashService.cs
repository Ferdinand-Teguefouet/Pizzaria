using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaASP.services
{
    public class HashService : IHashService
    {
        public string Hash(string passaword, string salt = null)
        {
            SHA512CryptoServiceProvider provider = new();
            byte[] bytes = Encoding.UTF8.GetBytes(passaword + (salt ?? ""));
            byte[] encodeded = provider.ComputeHash(bytes);
            return Encoding.UTF8.GetString(encodeded);

        }
    }
}
