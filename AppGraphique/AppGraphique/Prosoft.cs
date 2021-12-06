using System;
using System.Collections.Generic;
using System.IO;
namespace AppGraphique
{
    public class Prosoft
    {
        public string source;
        public string dest;
        static private char[] passcode
        {
            get { return "Draugar".ToCharArray(); }
        }
        public int Cryptage(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                source = args[i];
                byte[] filesource = File.ReadAllBytes(source);
                File.WriteAllBytes(dest, xor(filesource));
            }
            

            return 0;

        }
        static private byte[] xor(byte[] source)
        {
            byte[] result = new byte[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = (byte)(source[i] ^ ((byte)passcode[i % passcode.Length]));

            }
            return result;
        }
    }
}