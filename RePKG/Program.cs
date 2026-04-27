using System;
using System.CommandLine;
using System.CommandLine.Help;
using RePKG.Commands;

namespace RePKG
{
    internal class Program
    {
        public static bool Closing;

        private static int Main(string[] args)
        {
            Console.CancelKeyPress += Cancel;

            var root = new RootCommand("RePKG - Wallpaper Engine package tool");
            root.Add(Extract.BuildCommand());
            root.Add(Info.BuildCommand());
            root.Action = new HelpAction();
            return root.Parse(args).Invoke();
        }

        private static void Cancel(object? sender, ConsoleCancelEventArgs e)
        {
            Closing = true;
            e.Cancel = true;
            Console.WriteLine("Terminating...");
        }
    }
}
