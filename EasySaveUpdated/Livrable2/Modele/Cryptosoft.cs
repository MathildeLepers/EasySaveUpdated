using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Livrable2.Modele
{
    public class Prosoft
    {
        public string source;
        public string dest;
        static private char[] passcode
        {
            get { return "Draugar".ToCharArray(); }
        }
        public void Cryptage(string FileSource, string FileDestination)
        {

            byte[] filesource = File.ReadAllBytes(FileSource);
            File.WriteAllBytes(FileDestination, xor(filesource));

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
