using System;
using System.Diagnostics;

namespace Boxing;
internal class Program
{
    static void Main(string[] args)
    {
        int size = 1_000_000;
        int[] src = new int[size];
        int[] idst = new int[size];
        object[] odst = new object[size];
        Random rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            src[i] = rnd.Next();
        }
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < size; i++) idst[i] = src[i];
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
        sw.Restart();
        for (int i = 0; i < size; i++) odst[i] = src[i];
        sw.Stop();
        Console.WriteLine(sw.Elapsed);


    }
}
