namespace Core.BangunDatar
{
    class BangunDatar
    {
        public const string LUAS = "luas";
        public const string KELILING = "keliling";

        private bool useQuestion = false;
        private string type = LUAS;

        private string ask(string question)
        {
            Console.Write(question);
            string? answer = Console.ReadLine();

            if (answer == null)
            {
                return "";
            }

            return answer;
        }

        public void question()
        {
            this.useQuestion = true;
            string type = this.ask("Ingin menghitung bangun datar apa? (Luas/Keliling): ");

            string lowered = type.ToLower();

            if (!(lowered == LUAS || lowered == KELILING))
            {
                Console.WriteLine("Ups. Ga boleh gitu bang.");
                this.question();
            }

            this.type = type;
        }

        public void luas()
        {

        }

        public void keliling()
        {

        }
    }
}