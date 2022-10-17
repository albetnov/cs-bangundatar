namespace Core.BangunDatar
{
    class BangunDatar
    {
        private const string LUAS = "luas";
        private const string KELILING = "keliling";

        public const string PERSEGI = "persegi";
        public const string PERSEGI_PANJANG = "persegi panjang";
        public const string SEGITIGA = "segitiga";
        public const string JAJAR_GENJANG = "jajar genjang";
        public const string TRAPESIUM = "trapesium";
        private string ask(string question)
        {
            Console.Write(question);
            string? answer = Console.ReadLine();

            return answer ?? "";
        }

        public void question()
        {
            string type = this.ask("Ingin menghitung bangun datar apa? (Luas/Keliling): ");

            string lowered = type.ToLower();

            if (!(lowered == LUAS || lowered == KELILING))
            {
                Console.WriteLine("Ups. Ga boleh gitu bang.");
                this.question();
            }

            if (lowered == LUAS)
            {
                this.luas();
            }

            this.keliling();
        }

        public void checkArgument(string arg)
        {
            string lowered = arg.ToLower();
            string[] availableType = { PERSEGI, PERSEGI_PANJANG, SEGITIGA, TRAPESIUM, JAJAR_GENJANG };
            List<string> type = new List<string>(availableType);

            if (!type.Contains(lowered))
            {
                Console.WriteLine("Apa tuh??");
                System.Environment.Exit(1);
            }
        }

        public void luas()
        {
            Console.WriteLine("Luas!");
        }

        public void keliling()
        {
            Console.WriteLine("Keliling!");
        }
    }
}