using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input file name with extension:");
            string filename = Console.ReadLine();
            Console.WriteLine("Input encoded file name :");
            string encfilename = Console.ReadLine();
            Console.WriteLine("Input output file name with extension:");
            string outfilename = Console.ReadLine();


            ANSI ansi = new ANSI();
            string text = File.ReadAllText(filename, System.Text.ASCIIEncoding.Default);
            LZWCompressor encoder = new LZWCompressor(ansi);
            byte[] b = encoder.EncodeToByteList(text);
            File.WriteAllBytes(encfilename, b);

            Console.WriteLine("File " + filename + " encoded to " + encfilename);

            Console.WriteLine();
            Console.WriteLine("Start decoding " + encfilename);
            LZWDecompressor decoder = new LZWDecompressor(ansi);
            byte[] bo = File.ReadAllBytes(encfilename);
            string decodedOutput = decoder.DecodeFromCodes(bo);
            File.WriteAllText(outfilename, decodedOutput, System.Text.Encoding.Default);

            Console.WriteLine("File " + encfilename + " decoded to " + outfilename);            
        }
    }
}
