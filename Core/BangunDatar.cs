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
        string type = this.cli.ask("Ingin menghitung bangun datar apa? (Luas/Keliling): ", BangunDatar.LUAS);

        string lowered = type.ToLower();

        if (!(lowered == LUAS || lowered == KELILING))
        {
            Console.WriteLine("Ups. Ga boleh gitu bang.");
            this.question();
            return;
        }

        if (lowered == LUAS)
        {
            this.luas();
            return;
        }

        this.keliling();
        return;
    }

    public string checkArgument(string arg)
    {
        string lowered = arg.ToLower();
        if (lowered == "jajargenjang")
        {
            lowered = JAJAR_GENJANG;
        }
        if (lowered == "persegipanjang")
        {
            lowered = PERSEGI_PANJANG;
        }
        string[] availableType = { PERSEGI, PERSEGI_PANJANG, SEGITIGA, TRAPESIUM, JAJAR_GENJANG };
        List<string> type = new List<string>(availableType);

        if (!type.Contains(lowered))
        {
            Console.WriteLine("Apa tuh??");
            System.Environment.Exit(1);
        }
        return lowered;
    }

    private string menus()
    {
        Console.WriteLine("=====DAFTAR BANGUN DATAR=====");
        Console.WriteLine("1. Persegi");
        Console.WriteLine("2. Persegi Panjang");
        Console.WriteLine("3. Segitiga");
        Console.WriteLine("4. Trapesium");
        Console.WriteLine("5. Jajar Genjang");

        string type = this.cli.ask("Jenis Bangun Datar Apa yang kamu inginkan? (1-5): ", Convert.ToString(1));

        if (type.Trim() == "")
        {
            Console.WriteLine("Invalid mas.");
            this.menus();
            return "";
        }

        int typedInt = int.Parse(type);

        if (typedInt < 0 || typedInt > 5)
        {
            Console.WriteLine("Invalid mas.");
            this.menus();
            return "";
        }

        Dictionary<int, string> luasDirectory = new Dictionary<int, string>() {
            {1, BangunDatar.PERSEGI},
            {2, BangunDatar.PERSEGI_PANJANG},
            {3, BangunDatar.SEGITIGA},
            {4, BangunDatar.JAJAR_GENJANG},
            {5, BangunDatar.TRAPESIUM}
        };

        return luasDirectory[typedInt];
    }

    private dynamic getFlatBuild(string? eksplisit)
    {
        dynamic bangunDatar;
        string getMenu = eksplisit != null ? eksplisit : this.menus();

        Console.WriteLine(getMenu);

        switch (getMenu)
        {
            case BangunDatar.PERSEGI:
                Console.WriteLine("=====Persegi=====");
                bangunDatar = new Persegi();
                break;
            case BangunDatar.PERSEGI_PANJANG:
                Console.WriteLine("=====Persegi Panjang=====");
                bangunDatar = new PersegiPanjang();
                break;
            case BangunDatar.JAJAR_GENJANG:
                Console.WriteLine("=====Jajar Genjang=====");
                bangunDatar = new JajarGenjang();
                break;
            case BangunDatar.SEGITIGA:
                Console.WriteLine("=====Segitiga=====");
                bangunDatar = new Segitiga();
                break;
            default:
                Console.WriteLine("=====Trapesium=====");
                bangunDatar = new Trapesium();
                break;
        }
        return bangunDatar;
    }

    public void luas(string? eksplisit = null)
    {
        var bangunDatar = this.getFlatBuild(eksplisit);
        Console.WriteLine("=====LUAS=====");
        Console.WriteLine("Hasil Luas: {0}", bangunDatar.handler(BangunDatar.LUAS));
        return;
    }

    public void keliling(string? eksplisit = null)
    {
        var bangunDatar = this.getFlatBuild(eksplisit);
        Console.WriteLine("=====KELILING=====");
        Console.WriteLine("Hasil Luas: {0}", bangunDatar.handler(BangunDatar.KELILING));
        return;
    }
}