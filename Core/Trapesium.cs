namespace Core;

class Trapesium : BaseBangunDatar
{
    private double sisi1, sisi2, sisi3, sisi4;

    private double pair;

    private bool searchPair()
    {
        double[] allSets = { sisi1, sisi2, sisi3, sisi4 };

        var groups = allSets.GroupBy(v => v);

        double currentItem = 0;

        foreach (var group in groups)
            if (group.Count() == 2) currentItem = group.Key;

        if (currentItem != 0)
        {
            this.pair = currentItem;
            return true;
        }

        return false;
    }

    private bool setSisi3(double value)
    {
        bool pair = this.searchPair();
        if (pair && this.pair == value)
        {
            Console.WriteLine("Invalid: Lebih dari 1 Pair (Sisi yang sama).");
            return false;
        }
        this.sisi3 = value;
        return true;
    }

    private bool setSisi4(double value)
    {
        bool pair = this.searchPair();
        if (pair && this.pair == value)
        {
            Console.WriteLine("Invalid: Lebih dari 1 Pair (Sisi yang sama).");
            return false;
        }
        this.sisi4 = value;
        return true;
    }

    private void reset()
    {
        this.sisi1 = 0;
        this.sisi2 = 0;
        this.sisi3 = 0;
        this.sisi4 = 0;
        this.pair = 0;
    }

    public override double handler(string type)
    {
        this.reset();
        this.cli.typeSatisfier(type);

        this.sisi1 = this.cli.toDouble().ask("Berapa sisi ke-1? ", Convert.ToString(10));
        this.sisi2 = this.cli.toDouble().ask("Berapa sisi ke-2? ", Convert.ToString(this.sisi1));

        bool sisi3 = this.setSisi3(this.cli.toDouble().ask("Berapa sisi ke-3? ", Convert.ToString(this.sisi2)));

        if (!sisi3)
        {
            return this.handler(type);
        }

        bool sisi4 = this.setSisi4(this.cli.toDouble().ask("Berapa sisi ke-4? ", Convert.ToString(this.sisi3)));

        if (!sisi4)
        {
            return this.handler(type);
        }

        bool pair = this.searchPair();

        if (!pair)
        {
            Console.WriteLine("Tidak ditemukan sisi yang sama. Mengulang Pertanyaan.");
            return this.handler(type);
        }

        if (type == BangunDatar.LUAS)
        {
            return this.luas();
        }

        return this.keliling();
    }

    public double luas()
    {
        double tinggi = this.cli.toDouble().ask("Berapa tingginya? ", Convert.ToString(10));
        Console.WriteLine(tinggi);
        Console.WriteLine(this.pair);
        return 0.5 * (this.pair * 2) * tinggi;
    }

    public double keliling()
    {
        return this.sisi1 + this.sisi2 + this.sisi3 + this.sisi4;
    }
}