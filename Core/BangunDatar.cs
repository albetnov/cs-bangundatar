namespace Core;
class BangunDatar
{
    public const string LUAS = "luas";
    public const string KELILING = "keliling";

    public const string PERSEGI = "persegi";
    public const string PERSEGI_PANJANG = "persegi panjang";
    public const string SEGITIGA = "segitiga";
    public const string JAJAR_GENJANG = "jajar genjang";
    public const string TRAPESIUM = "trapesium";

    private CliHelper cli;

    public BangunDatar()
    {
        this.cli = new CliHelper().disableToDouble();
    }
    public void question()
    {
        string type = this.cli.ask("Ingin menghitung bangun datar apa? (Luas/Keliling): ");

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

    private int menus()
    {
        Console.WriteLine("=====DAFTAR BANGUN DATAR=====");
        Console.WriteLine("1. Persegi");
        Console.WriteLine("2. Persegi Panjang");
        Console.WriteLine("3. Segitiga");
        Console.WriteLine("4. Trapesium");
        Console.WriteLine("5. Jajar Genjang");

        string type = this.cli.ask("Jenis Bangun Datar Apa yang kamu inginkan? (1-5): ");

        if (type.Trim() == "")
        {
            Console.WriteLine("Invalid mas.");
            this.menus();
            return 0;
        }

        int typedInt = int.Parse(type);

        if (typedInt < 0 || typedInt > 5)
        {
            Console.WriteLine("Invalid mas.");
            this.menus();
            return 0;
        }

        return typedInt;
    }

    public void luas()
    {
        Console.WriteLine("=====LUAS=====");
        int choice = this.menus();

        Trapesium trapesium = new Trapesium();

        trapesium.handler(BangunDatar.LUAS);
        return;

        // Dictionary<int, string> luasDirectory = new Dictionary<int, string>() {
        //     {0, }
        // };
    }

    public void keliling()
    {
        Console.WriteLine("Keliling!");
    }
}