using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NAudio.Wave;

namespace FiszkiPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string mp3FilesDir = Directory.GetCurrentDirectory();

            if (args.Length > 0)
            {
                mp3FilesDir = args.First();
            }

            var waveOutDevice = new WaveOut();

            var idToFile = Directory.GetFiles(mp3FilesDir, "*.mp3", SearchOption.AllDirectories).ToDictionary(k => int.Parse(Regex.Match(Path.GetFileName(k), @"^\d+").Value));
            while (true)
            {
                Console.WriteLine("Wprowadz numer nagrania");
                var trackId = int.Parse(Console.ReadLine());

                using (var audioFileReader = new AudioFileReader(idToFile[trackId]))
                {
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();

                    Console.ReadLine();
                }
            }
            
        }
    }
}
