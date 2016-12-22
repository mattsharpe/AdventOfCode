﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace AdventOfCode.Solutions
{
    /*
    --- Day 5: How About a Nice Game of Chess? ---

    You are faced with a security door designed by Easter Bunny engineers that seem to have acquired most of their security knowledge by watching hacking movies.

    The eight-character password for the door is generated one character at a time by finding the MD5 hash of some Door ID (your puzzle input) and an increasing integer index (starting with 0).

    A hash indicates the next character in the password if its hexadecimal representation starts with five zeroes. If it does, the sixth character in the hash is the next character of the password.

    For example, if the Door ID is abc:

    The first index which produces a hash that starts with five zeroes is 3231929, which we find by hashing abc3231929; the sixth character of the hash, and thus the first character of the password, is 1.
    5017308 produces the next interesting hash, which starts with 000008f82..., so the second character of the password is 8.
    The third time a hash starts with five zeroes is for abc5278568, discovering the character f.
    In this example, after continuing this search a total of eight times, the password is 18f47a30.

    Given the actual Door ID, what is the password?

    Your puzzle input is ugkcyxxp.
    */


    public class Day5
    {
        private MD5 _md5;

        public Day5()
        {
            _md5 = MD5.Create();
        }
        public string Md5Hash(string input)
        {
            byte[] data = _md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(data).Replace("-", "");
        }
        
        public string CalculatePassword(string input)
        {
            var sb = new StringBuilder();
            int index = 0;
            while (sb.Length < 8)
            {
                var hash = Md5Hash($"{input}{index}");
                if (hash.StartsWith("00000"))
                {
                    Console.WriteLine($"found a hash {hash}");
                    sb.Append(hash.Substring(5, 1));
                }

                index++;
            }
            
            return sb.ToString().ToLower();
        }

        public string CalculatePasswordWithOrder(string door)
        {
            char?[] password = new char?[8];
            int index = 0;
            while (password.Where(x => x != null).Count()  < 8)
            {
                var hash = Md5Hash($"{door}{index}");
                if (hash.StartsWith("00000"))
                {
                    if (char.IsDigit(hash[5]))
                    {
                        var location = Convert.ToInt32(char.GetNumericValue(hash[5]));

                        if (location < 8 && password[location] == null)
                        {
                            password[location] = hash[6];
                        }
                    }
                }
                index++;
            }

            return string.Join("",password).ToLower();
        }
    }
}
