using System;
using System.Threading;
class Program
{
    static void Main()
    { 
    String line = "........................................";
    int Length = line.Length;
    for(int i = 0 ; i<Length; i++)
        {
        Console.Write("\r"+ new String (' ',i)+"C"+line.Substring(i+1));
        Thread.Sleep(200);
        Console.Write("\r"+ new String(' ',i+1)+"C"+line.Substring(i+1));
        Thread.Sleep(200);
}

    Console.Write("\r" + new String(' ', Length) + "C");
    Console.WriteLine("\n\nGameOver!Pac-Man ate all the dots!");
}}