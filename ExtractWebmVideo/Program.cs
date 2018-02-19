using System;
using System.IO;

namespace ExtractWebmVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: ExtractWebmVideo c:\\directory\\to\\import");
                return;
            }
            try
            {
                var files = Directory.GetFiles(args[0]);
                foreach (var file in files)
                {
                    ImortFile(file);
                }
            } 
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("The directory could not be found: " + args[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading directory: " + ex.Message);
            }
        }

        private static void ImortFile(string file)
        {
            try
            {
                byte[] inputBytes = File.ReadAllBytes(file);
                var start = FindStart(inputBytes);
                if (start == -1)
                {
                    Console.WriteLine("No start found for file " + file + ", no video could be extracted");
                }
                else
                {
                    var fileNameOut = file + "-converted.webm";
                    var target = File.OpenWrite(fileNameOut);
                    target.Write(inputBytes, start, inputBytes.Length - start);
                    target.Close();
                    Console.WriteLine("Extracted video from " + file + " into " + fileNameOut);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error extracting video from " + file + ": " + ex.Message);
            }
        }

        private static int FindStart(byte[] inputBytes)
        {
            for (var i = 0; i < inputBytes.Length - 3; i++)
            {
                if (inputBytes[i] == 0x1A
                    && inputBytes[i + 1] == 0x45
                    && inputBytes[i + 2] == 0xDF
                    && inputBytes[i + 3] == 0xA3)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
