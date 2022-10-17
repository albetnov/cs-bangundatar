using System;
using Parser.CommandLineParser;

namespace Program
{
    class BangunDatar
    {
        static void Main(string[] args)
        {
            CommandLineParser parser = new CommandLineParser(args);
            parser.parse();
        }
    }
}