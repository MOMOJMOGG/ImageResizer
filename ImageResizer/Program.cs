using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            string destinationPath = Path.Combine(Environment.CurrentDirectory, "output"); ;

            ImageProcess imageProcess = new ImageProcess();

            imageProcess.Clean(destinationPath);
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath, 2.0);
            sw1.Stop();
            Console.WriteLine($"修改前花費時間: {sw1.ElapsedMilliseconds} ms");

            imageProcess.Clean(destinationPath);
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            var result = imageProcess.ResizeImagesAsync(sourcePath, destinationPath, 2.0);
            Task.WaitAll(result);
            sw2.Stop();

            Console.WriteLine($"修改後花費時間: {sw2.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }
    }
}
