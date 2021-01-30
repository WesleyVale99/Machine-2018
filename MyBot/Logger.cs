using System;

namespace AsyncRun
{
    public class Logger
    {
        public static void Info(string info)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        public static void Mostrar(string info)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        public static void Error(string info)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        public static void Warnnig(string info)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        public static void Conta(string info)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(info);
            Console.ResetColor();
        }
        public static void Sucess(string info)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        public static void Receive(string info)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ReadPacket: {info}");
            Console.ResetColor();
        }
        public static void Comandos(string info)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{info}");
            Console.ResetColor();
        }
        public static void Send(string info)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"SendPacket: {info}");
            Console.ResetColor();
        }
    }
}
