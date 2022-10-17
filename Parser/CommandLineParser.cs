using System;
using Core.BangunDatar;

namespace Parser.CommandLineParser
{
    class CommandLineParser
    {
        private string[] args;
        private BangunDatar bangunDatar;
        public CommandLineParser(string[] args)
        {
            this.args = args;
            this.bangunDatar = new BangunDatar();
        }
        private string? getFirstArgs()
        {
            return this.args.Length >= 1 ? this.args[0] : null;
        }

        private string? getSecondArgs()
        {
            return this.args.Length >= 2 ? this.args[1] : null;
        }

        public void parse()
        {
            string? firstArg = this.getFirstArgs();
            string? secondArg = this.getSecondArgs();

            if (firstArg != null)
            {
                switch (firstArg)
                {
                    case "--version":
                        Console.WriteLine("BangunDatar By Albet Novendo");
                        Console.WriteLine("Version: 1.0");
                        System.Environment.Exit(1);
                        break;
                    case "--luas":
                    case "-l":
                        if (secondArg != null)
                        {
                            this.bangunDatar.checkArgument(secondArg);
                            this.bangunDatar.luas();
                            return;
                        }
                        Console.WriteLine("Argument {luas} harus di isi.");
                        System.Environment.Exit(1);
                        break;
                    case "--keliling":
                    case "-k":
                        if (secondArg != null)
                        {
                            this.bangunDatar.checkArgument(secondArg);
                            this.bangunDatar.keliling();
                            return;
                        }
                        Console.WriteLine("Argument {keliling} harus di isi.");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Argument tidak di kenali");
                        System.Environment.Exit(1);
                        break;
                }
            }

            this.bangunDatar.question();
            return;
        }
    }
}