using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FiszkiPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var idToFile = Directory.GetFiles(@"c:\a\samplemp3", "*.mp3", SearchOption.AllDirectories).ToDictionary(k => int.Parse(Regex.Match(Path.GetFileName(k), @"\d+").Value));

        }
    }
}
