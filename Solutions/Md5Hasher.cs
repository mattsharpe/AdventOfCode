using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Solutions
{
    public class Md5Hasher
    {
        private MD5 _md5;

        public Md5Hasher()
        {
            _md5 = MD5.Create();
        }

        public string Md5Hash(string input)
        {
            byte[] data = _md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(data).Replace("-", "");
        }
    }
}